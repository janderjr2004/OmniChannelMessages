using System.Runtime.Serialization;

namespace OC.Entities
{
    public class UserTypeChannel : BaseEntity
    {
        public int UserId { get; set; }
        public int TypeChannelId { get; set; }

        [IgnoreDataMember]
        public virtual User User { get; set; }

        [IgnoreDataMember]
        public virtual TypeChannel TypeChannel { get; set; }
    }
}
