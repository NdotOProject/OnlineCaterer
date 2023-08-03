
namespace OnlineCaterer.Domain.Entities;

public class Place
{
    //[Key]
    public int Id { get; set; }

    //[Required]
    //[Column(TypeName = "nvarchar")]
    //[StringLength(500)]
    public string? Name { get; set; }

    public ICollection<Caterer> Caterers { get; set; } = new HashSet<Caterer>();
}
