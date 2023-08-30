using OnlineCaterer.Application.Initialization;
using System.Text.Json;

namespace OnlineCaterer.Web.Services;

public class CompanyInfoReader
{
    public static CompanyInfo GetCompanyInfo()
    {
        string json = File.ReadAllText(@"company-info.json");
        string introdcution = File.ReadAllText(@"introduction.txt");

        var companyInfo = JsonSerializer.Deserialize<CompanyInfo>(json) ?? new CompanyInfo();
        companyInfo.Introduction = introdcution;

        return companyInfo;
    }
}
