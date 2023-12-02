namespace AppSettingsTest
{
    public class AppConfig : IAppConfig
    {
        public readonly string mailSecret = string.Empty;
        public readonly string adminPass = string.Empty;

        public IConfiguration Configuration { get; }
        public AppConfig(IConfiguration configuration)
        {
            Configuration = configuration;
            mailSecret = Configuration["ApplicationSecrets:MailSecret"];
            adminPass = Configuration["ApplicationSecrets:AdminPass"];
        }

        public string GetMailSecret()
        {
            return mailSecret;
        }
        public string GetAdminPass()
        {
            return mailSecret;
        }
    }
    public interface IAppConfig
    {
        string GetMailSecret();
        string GetAdminPass();
    }
}
