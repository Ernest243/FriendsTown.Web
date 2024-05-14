namespace FriendsTown.Web.Models
{
    public class FriendApiModel
    {
        public IEnumerable<FriendApiItem> FriendsList { get; set; }
    }

    public class FriendApiItem 
    {
        public string Id { get; set; }
        public string Name { get; set; }    
    }
}
