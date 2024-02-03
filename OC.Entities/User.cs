using System.Runtime.Serialization;

namespace OC.Entities
{
    public class User : BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<LogMessage> LogMessages { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<UserTypeChannel> UserTypeChannel { get; set; }
    }
}
