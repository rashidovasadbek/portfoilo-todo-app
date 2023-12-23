namespace ToDo.Domain.Common.Entities;

public class AuditableEntity : Entity, IAuditableEntity
{
    public DateTimeOffset CreatedTime { get; set; }
    
    public DateTimeOffset? ModifiedTime { get; set; }
}