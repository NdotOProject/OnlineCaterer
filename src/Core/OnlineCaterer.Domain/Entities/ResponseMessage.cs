
namespace OnlineCaterer.Domain.Entities;

public class ResponseMessage : BaseEntity
{
    //[Key]
    public int Id { get; set; }

    //[Required]
    //[ForeignKey(nameof(Caterer))]
    public string? CatererId { get; set; }
    public Caterer? Caterer { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }// = string.Empty;

    public DateTime ResponseDate { get; set; }// = DateTime.Now;

}
