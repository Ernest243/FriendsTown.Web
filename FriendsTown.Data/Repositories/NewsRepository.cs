using FriendsTown.Domain;

namespace FriendsTown.Data.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly FriendsTownContext _context;

        public NewsRepository(FriendsTownContext context)
        {
            _context = context;
        }

        public void Add(News news) 
        {
            _context.Add(news);
            _context.SaveChanges();
        }

        public News FindById(Guid id) 
        {
            return _context.News.Find(id);
        }

        public IEnumerable<News> GetAll() 
        {
            return _context.News.OrderBy(a => a.Date.Value);
        }
    }
}
