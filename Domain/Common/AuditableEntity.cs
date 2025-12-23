namespace Domain.Common;

public abstract class AuditableEntity
{

    public int CreatedUserId { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public int? ModifiedUserId { get; set; }
    public DateTime? ModifiedDateTime { get; set; }

}