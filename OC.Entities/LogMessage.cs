using System.Runtime.Serialization;

namespace OC.Entities
{
    public class LogMessage : BaseEntity
    {
        public int TypeChannelId { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public string Referent { get; set; }
        public string Recipient { get; set; }
        public int UserId { get; set; }

        [IgnoreDataMember]
        public virtual User User { get; set; }        
        
        [IgnoreDataMember]
        public virtual TypeChannel TypeChannel { get; set; }
    }
}