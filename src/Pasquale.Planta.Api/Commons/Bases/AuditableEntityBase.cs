namespace Pasquale.Planta.Api.Commons.Bases;

public class AuditableEntityBase
{
    public string CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }
}