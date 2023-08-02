
using OnlineCaterer.Domain.Common;

namespace OnlineCaterer.Domain.Entities;

public class Place : BaseEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar")]
    [StringLength(500, MinimumLength = 1)]
    public string? Name { get; set; }

}
