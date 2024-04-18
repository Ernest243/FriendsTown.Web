using FriendsTown.Domain;

namespace FriendsTown.Data.Repositories
{
    public interface IActivityRepository
    {
        IEnumerable<Activity> GetAll();
        Activity FindById(Guid id);
        void Add(Activity activity);
        void Update(Activity activity);
        void Delete(Guid id);
    }
}
