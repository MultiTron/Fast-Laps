namespace FL.Website.Models
{
    public class EditDriverViewModel
    {
        public int Id { get; set; }
        public Dictionary<int, string> Cars { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CarId { get; set; }
    }
}
