using FriendsTown.Domain;

namespace FriendsTown.Data.Repositories
{
    public class FriendRepository : IFriendRepository
    {
        private readonly FriendsTownContext _context;

        public FriendRepository(FriendsTownContext context)
        {
            _context = context;
        }

        public void Add(Friend friend) 
        {
            _context.Add(friend);
            _context.SaveChanges();
        }

        public Friend FindById(Guid id) 
        {
            return _context.Friends.Find(id);
        }

        public IEnumerable<Friend> GetAll() 
        {
            return _context.Friends.OrderBy(a => a.Name);
        }

        public IEnumerable<Friend> GetByName(string name) 
        {
            return _context.Friends.Where(a => a.Name.Contains(name))
                .OrderBy(a => a.Name);
        }
    }
}
