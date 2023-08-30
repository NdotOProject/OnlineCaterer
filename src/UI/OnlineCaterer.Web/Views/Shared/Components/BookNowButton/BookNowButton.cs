using Microsoft.AspNetCore.Mvc;

namespace OnlineCaterer.Web.Views.Shared.Components.BookNowButton
{
    public class BookNowButton
    {
        public string CatererId { get; private set; }

        public BookNowButton(string? catererId)
        {
            CatererId = catererId ?? "";
        }
    }
}
