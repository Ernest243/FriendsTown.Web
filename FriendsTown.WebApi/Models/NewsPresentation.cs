namespace FriendsTown.WebApi.Models
{
    public class NewsPresentation
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public PlacePresentation Place {  get; set; }

        public string Description { get; set; }
    }
}
