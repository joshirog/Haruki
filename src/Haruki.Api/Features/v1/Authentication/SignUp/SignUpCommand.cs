using System.Security.Claims;
using AutoMapper;
using Haruki.Api.Commons.Bases;
using Haruki.Api.Commons.Constants;
using Haruki.Api.Commons.Exceptions;
using Haruki.Api.Domains.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Haruki.Api.Features.v1.Authentication.SignUp;

public class SignUpCommand : IRequest<ResponseBase<bool>>
{
    public SignUpCommand(string firstName, string lastName, string email, string phoneNumber, string password, string confirmPassword)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Password = password;
        ConfirmPassword = confirmPassword;
    }

    public string RoleId { get; set; }
    
    public string FirstName { get; }
    
    public string LastName { get; }
    
    public string Email { get; }
    
    public string PhoneNumber { get; }
    
    public string Password { get; }
    
    public string ConfirmPassword { get; }
}

public class SignUpHandler : IRequestHandler<SignUpCommand, ResponseBase<bool>>
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    
    public SignUpHandler(UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper, IMediator mediator)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _mapper = mapper;
        _mediator = mediator;
    }
    
    public async Task<ResponseBase<bool>> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.RoleId))
            request.RoleId = RoleConstant.GuestId;
        
        var role = await _roleManager.FindByIdAsync(request.RoleId);
        
        if(role is null)
            throw new Exception("The role does not exist");
        
        var user = _mapper.Map<User>(request);
        
        var identityResult = await _userManager.CreateAsync(user, request.Password);
            
        if (!identityResult.Succeeded)
            throw new ErrorInvalidException(identityResult.Errors.Select(x => x.Description));
        
        identityResult = await _userManager.AddToRoleAsync(user, role.Name!);

        if (!identityResult.Succeeded)
            throw new ErrorInvalidException(identityResult.Errors.Select(x => x.Description));
        
        identityResult = await _userManager.AddClaimsAsync(user, new List<Claim>
        {
            new("identifier", user.Id.ToString()),
            new("first_name", request.FirstName),
            new("last_name", request.LastName),
            new("nick_name", $"{request.FirstName[..1]}{request.LastName[..1]}"),
            new("avatar", GeneralConstant.DefaultAvatar, ClaimValueTypes.String)
        });
        
        switch (identityResult.Succeeded)
        {
            case false:
                throw new ErrorInvalidException(identityResult.Errors.Select(x => x.Description));
            case true:
                await _mediator.Publish(new SignUpNotification{ UserName = user.UserName, ReturnUrl = "" }, cancellationToken);
                break;
        }

        return Response.Ok(ResponseConstant.MessageSuccess, identityResult.Succeeded);
    }
}