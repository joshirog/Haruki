using Microsoft.AspNetCore.Identity;
using Pasquale.Plant.Api.Commons.Bases;

namespace Pasquale.Plant.Api.Domains.Entities;

public class Role : IdentityRole<Guid>, AuditableEntityBase
{
    public string CreatedBy { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public string UpdatedBy { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
}