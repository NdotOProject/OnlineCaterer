
namespace OnlineCaterer.Application.DTOs.Users.Caterer;

public class AuditableCatererResponse
{
    public SimpleCatererResponse? Information { get; set; }

    public DateTime CreatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public string? LastModifiedBy { get; set; }

}
