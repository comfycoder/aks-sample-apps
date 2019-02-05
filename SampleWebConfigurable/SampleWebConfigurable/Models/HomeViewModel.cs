
namespace SampleWebConfigurable.Models
{
    public class HomeViewModel
    {
        public string TestSetting { get; set; }

        public string EnvironmentName { get; set; }
        public string HostName { get; set; }
        public string MySetting { get; set; }
        public string MySecret { get; set; }
        public string MySecretFile = "/kvmnt/MySecret";
    }
}
