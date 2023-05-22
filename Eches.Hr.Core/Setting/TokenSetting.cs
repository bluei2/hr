namespace Eches.Hr.Core.Setting
{
    public class TokenSetting
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double AccessExpiration { get; set; }
        public double RefreshExpiration { get; set; }
    }
}


