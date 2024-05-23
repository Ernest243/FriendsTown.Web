using FriendsTown.Domain;
using Microsoft.EntityFrameworkCore;

namespace FriendsTown.Data.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly FriendsTownContext _context;

        public EventRepository(FriendsTownContext context)
        {
            _context = context;
        }

        public void Add(Event newEvent)
        {
            _context.Add(newEvent);
            _context.SaveChanges();
        }

        public Event FindById(Guid id)
        {
            return _context.Events
                .Include(ev => ev.ActivityType)
                .Include(ev => ev.Organizer)
                .FirstOrDefault(ev => ev.Id == id);
        }

        public IEnumerable<Event> GetAll()
        {
            return _context.Events
            .Include(ev => ev.ActivityType)
            .Include(_ev => _ev.Organizer)
            .OrderBy(ev => ev.Date.Value);
        }

        public List<Event> GetEvents()
        {
            return _context.Events
                .Include(e => e.Organizer)
                .Include(e => e.ActivityType)
                .Include(e => e.Offers)
                .OrderBy(a => a.Date.Value)
                .ToList();
        }
    }
}