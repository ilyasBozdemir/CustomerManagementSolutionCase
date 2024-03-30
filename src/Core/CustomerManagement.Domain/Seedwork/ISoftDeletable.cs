namespace CustomerManagement.Domain.Seedwork;

public interface ISoftDeletable
{
    bool IsDeleted { get; set; }
    DateTime? DeletedDate { get; set; }
}
