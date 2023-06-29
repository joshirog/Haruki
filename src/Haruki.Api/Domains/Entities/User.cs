using Haruki.Api.Commons.Bases;
using Microsoft.AspNetCore.Identity;

namespace Haruki.Api.Domains.Entities;

public class User : IdentityUser<Guid>, AuditableEntityBase
{
    public string Status { get; set; }
    
    public string CreatedBy { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public string UpdatedBy { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
}