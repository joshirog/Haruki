using Haruki.Api.Commons.Bases;

namespace Haruki.Api.Domains.Entities;

public class Service : AuditableEntityBase
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    
    public string CreatedBy { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public string UpdatedBy { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
}