
namespace OnlineCaterer.Domain.Common;

public abstract class BaseEntity
{
    [DataType(DataType.DateTime)]
    public DateTime CreatedDate { get; set; }

    [Column(TypeName = "nvarchar")]
    [StringLength(450)]
    public string? CreatedBy { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime? LastModifiedDate { get; set;}

    [Column(TypeName = "nvarchar")]
    [StringLength(450)]
    public string? LastModifiedBy { get; set; }
}
