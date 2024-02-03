using System.Runtime.Serialization;

namespace OC.Entities
{
    public class TypeChannel : BaseEntity
    {
        public string Name { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<LogMessage> LogMessages { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<UserTypeChannel> UserTypeChannel { get; set; }
    }
}
