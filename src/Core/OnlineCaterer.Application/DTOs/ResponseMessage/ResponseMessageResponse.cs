
namespace OnlineCaterer.Application.DTOs.ResponseMessage;

public class ResponseMessageResponse
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public DateTime ResponseDate { get; set; }

    // Không in
    public string CatererId { get; set; }
}
