
namespace OnlineCaterer.Domain.Entities;

public class Place
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public ICollection<Caterer> Caterers { get; set; } = new HashSet<Caterer>();
}
