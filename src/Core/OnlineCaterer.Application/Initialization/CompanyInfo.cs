
namespace OnlineCaterer.Application.Initialization;

public class CompanyInfo
{
    public string Brand { get; set; }

    public string Address { get; set; }
    public string Location { get; set; }

    public string Phone { get; set; }

    public string Mail { get; set; }

    public string Introduction { get; set; }

    public SocialMedia Facebook { get; set; }

    public SocialMedia Twitter { get; set; }

    public SocialMedia Linkedin { get; set;}

    public SocialMedia Instagram { get;set; }

    public SocialMedia Pinterest { get;set; }

    public override string ToString()
    {
        string result = $"Company [" +
            $"\n {nameof(Brand)} : {Brand}," +
            $"\n {nameof(Address)} : {Address}," +
            $"\n {nameof(Location)} : {Location}," +
            $"\n {nameof(Phone)} : {Phone}," +
            $"\n {nameof(Mail)} : {Mail}," +
            $"\n {nameof(Introduction)} : {Introduction}," +
            $"\n {nameof(Facebook)} : {Facebook.Title}," +
            $"\n {nameof(Twitter)} : {Twitter.Title}," +
            $"\n {nameof(Linkedin)} : {Linkedin.Title}," +
            $"\n {nameof(Instagram)} : {Instagram.Title}," +
            $"\n {nameof(Pinterest)} : {Pinterest.Title}," +
            $"\n]";
        return result;
    }
}
