using Microsoft.AspNetCore.Identity;
using Pasquale.Plant.Api.Commons.Bases;

namespace Pasquale.Plant.Api.Domains.Entities;

public class User : IdentityUser<Guid>, AuditableEntityBase
{
    public string Status { get; set; }
    
    public string CreatedBy { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public string UpdatedBy { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
}