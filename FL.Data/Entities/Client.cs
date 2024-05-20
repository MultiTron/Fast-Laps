namespace FL.Data.Entities
{
    public class Client : BaseEntity
    {
        required public string Name { get; set; }
        required public string Secret { get; set; }
    }
}
