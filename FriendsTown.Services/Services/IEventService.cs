namespace FriendsTown.Services;

public interface IEventService
{
    List<DtoEventsWithOffers> GetEventsWithOffers();
    void RegisterEventWithOffers(DtoEventData eventData);
}
