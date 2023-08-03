
namespace OnlineCaterer.Domain.Common;

public abstract class BaseEntity
{
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime CreatedDate { get; set; }

    [Required]
    [Column(TypeName = "nvarchar")]
    [StringLength(450)]
    public string? CreatedBy { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime? LastModifiedDate { get; set;}

    [Required]
    [Column(TypeName = "nvarchar")]
    [StringLength(450)]
    public string? LastModifiedBy { get; set; }
}
