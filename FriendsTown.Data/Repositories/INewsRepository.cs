using FriendsTown.Domain;


namespace FriendsTown.Data.Repositories
{
    public interface INewsRepository
    {
        IEnumerable<News> GetAll();
        News FindById(Guid id);
        void Add(News news);
        void Update(News news);
        void Delete(Guid id);
    }
}
