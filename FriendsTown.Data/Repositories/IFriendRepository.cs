using FriendsTown.Domain;

namespace FriendsTown.Data.Repositories
{
    public interface IFriendRepository
    {
        IEnumerable<Friend> GetAll();
        Friend FindById(Guid id);
        void Add(Friend friend);
    }
}
