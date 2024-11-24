namespace MyApp.Domain.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public CompanySize Size { get; set; }
    }
}