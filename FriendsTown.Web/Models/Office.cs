namespace FriendsTown.Web.Models
{
    public class Office
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public List<Office> GetAll() 
        {
            return new List<Office> 
            {
                new Office { Code = "25", Name = "London" },
                new Office { Code = "32", Name = "New York" },
                new Office { Code = "47", Name = "Tokio" }
            };
        }
    }
}
