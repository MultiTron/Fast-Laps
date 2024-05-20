using System.ComponentModel.DataAnnotations;

namespace FL.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [Required]
        required public bool IsActive { get; set; }
    }
}
