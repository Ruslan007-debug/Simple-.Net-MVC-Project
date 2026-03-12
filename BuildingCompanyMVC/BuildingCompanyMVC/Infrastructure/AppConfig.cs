namespace BuildingCompanyMVC.Infrastructure
{
    public class AppConfig
    {
        public TinyMce TinyMCE { get; set; } = new TinyMce();

        public Company Company { get; set; } = new Company();

        public Database Database { get; set; } = new Database();
    }

    public class Database
    {
        public string? ConnectionString { get; set; }
    }

    public class TinyMce
    {
        public string? APIKey { get; set; }
    }

    public class Company
    {
        public string? CompanyName { get; set; }
        public string? CompanyPhone { get; set; }
        public string? CompanyPhoneShort { get; set; }
        public string? CompanyEmail { get; set; }
    }
}
