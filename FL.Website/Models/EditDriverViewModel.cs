using System.ComponentModel;

namespace FL.Website.Models
{
    public class EditDriverViewModel
    {
        public int Id { get; set; }
        public Dictionary<int, string> Cars { get; set; }
        [DisplayName("First name")]
        public string FirstName { get; set; }
        [DisplayName("Last name")]
        public string LastName { get; set; }
        [DisplayName("Car")]
        public int CarId { get; set; }
    }
}
