using FriendsTown.Data.Repositories;
using FriendsTown.Domain;


namespace FriendsTown.Services;

public class EventService : IEventService
{
    IFriendRepository _friendRepository;
    IActivityRepository _activityRepository;
    IEventRepository _eventRepository;

    public EventService (IFriendRepository friendRepository, IActivityRepository activityRepository, IEventRepository eventRepository)
    {
        _friendRepository = friendRepository;
        _activityRepository = activityRepository;
        _eventRepository = eventRepository;
    }

    public List<DtoEventsWithOffers> GetEventsWithOffers()
    {
        var events = _eventRepository.GetEvents().ToList();
        var results = events.SelectMany(ev => ev.Offers, (ev, o) => 
            new DtoEventsWithOffers 
            {
                Activity = ev.ActivityType.Name,
                Date = ev.Date.Value.ToShortDateString(),
                Organizer = ev.Organizer.Name,
                Place = ev.Place.ToString(),
                Offer = o.Description
            });

        return results.ToList();
    }

    public void RegisterEventWithOffers(DtoEventData eventData)
    {
        var organizer = _friendRepository.FindById(eventData.IdOrganizer);
        var activity = _activityRepository.FindById(eventData.IdActivity);
        var date = Date.FromString(eventData.Date);
        var place = Place.Create(eventData.City, eventData.Street, eventData.Number, eventData.Reference);
        Event newEvent = Event.Create(Guid.NewGuid(), organizer, activity, date, place, eventData.Offers);

        _eventRepository.Add(newEvent);
    }
}
