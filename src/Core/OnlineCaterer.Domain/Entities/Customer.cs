
using OnlineCaterer.Domain.Common;

namespace OnlineCaterer.Domain.Entities;

public class Customer : BaseEntity
{
    [Key]
    public int UserId { get; set; }

}
