using Haruki.Api.Commons.Bases;

namespace Haruki.Api.Domains.Entities;

public class Category : AuditableEntityBase
{
    public Guid Id { get; set; }

    public Guid ServiceId { get; set; }

    public string Name { get; set; }
    
    public string CreatedBy { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public string UpdatedBy { get; set; }
    
    public DateTime? UpdatedAt { get; set; }


    public Service Service{ get; set; }
}