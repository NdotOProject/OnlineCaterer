
namespace OnlineCaterer.Domain.Entities;

public class ResponseMessage : BaseEntity
{
    public int Id { get; set; }

    public string? CatererId { get; set; }
    public Caterer? Caterer { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public DateTime ResponseDate { get; set; }

}
