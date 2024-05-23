namespace FriendsTown.Services;

public class DtoEventData
{
    public string Date { get; set; }
    public Guid IdOrganizer { get; set; }
    public Guid IdActivity { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string Reference { get; set; }
    public List<string> Offers { get; set; }
}
