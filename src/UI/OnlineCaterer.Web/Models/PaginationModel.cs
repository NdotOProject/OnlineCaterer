using Microsoft.AspNetCore.Mvc;
using OnlineCaterer.Domain.Constants;

namespace OnlineCaterer.Web.Models
{
    public class PaginationModel
    {
        private const int DEFAULT_RANGE_SIZE = 1;

        private const int MAX_RANGE_SIZE = 5;

        private readonly IUrlHelper _urlHelper;

        public PaginationModel(IUrlHelper helper)
        {
            _urlHelper = helper;
        }

        private List<int> MakeRange()
        {
            List<int> range = new() { DEFAULT_RANGE_SIZE };

            if (TotalPages >= DEFAULT_RANGE_SIZE)
            {
                if (TotalPages < MAX_RANGE_SIZE)
                {
                    range = new List<int>(TotalPages);
                }
                else
                {
                    range = new List<int>(MAX_RANGE_SIZE);
                }

                range.Add(CurrentPage);

                for (int i = 1; range.Count < range.Capacity; i++)
                {
                    if (CurrentPage + i <= TotalPages)
                    {
                        range.Add(CurrentPage + i);
                    }

                    if (CurrentPage - i >= 1)
                    {
                        range.Insert(0, CurrentPage - i);
                    }
                }
            }

            return range;
        }

        public List<int> Range
        {
            get
            {
                return MakeRange();
            }
        }

        public string? GeneratedUrl { get; private set; }

        public string? PageName { private get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public bool Next()
        {
            if (CurrentPage >= TotalPages)
            {
                CurrentPage = TotalPages;
            }

            if (CurrentPage < TotalPages)
            {
                return CreateUrl(CurrentPage + 1) != null;
            }
            return false;
        }

        public bool Previous()
        {
            if (CurrentPage < 0)
            {
                CurrentPage = 1;
            }
            if (CurrentPage > 1)
            {
                return CreateUrl(CurrentPage - 1) != null;
            }
            return false;
        }

        public string? CreateUrl(int page)
        {
            return GeneratedUrl = PaginationQuery.MakeUrl(_urlHelper.Page(PageName), page);
        }

        public Dictionary<int, string?> CreateFromRange()
        {
            Dictionary<int, string?> result = new();
            foreach (var page in Range)
            {
                result.Add(page, CreateUrl(page));
            }

            return result;
        }

        public bool IsCurrentPage(KeyValuePair<int, string?> page)
        {
            return page.Key == CurrentPage;
        }

    }

}
