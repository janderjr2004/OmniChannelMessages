namespace OC.Libraries.Classes.AuxiliaryClasses
{
    public class SmtpConfiguration
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string Password { get; set; }
        public bool EnableSSL { get; set; }
        public bool IsHtml { get; set; }
    }
}