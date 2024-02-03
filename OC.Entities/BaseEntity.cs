using System.ComponentModel.DataAnnotations;

namespace OC.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
