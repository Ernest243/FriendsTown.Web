

namespace FriendsTown.Domain.Common
{
    public class Entity<TId> : IEquatable<Entity<TId>>
    {
        public TId Id { get; protected set; }

        protected Entity(TId id)
        {
            this.Id = !object.Equals(id, default(TId)) ? id :
                throw new ArgumentException("You cannot use the default value for Id", "id");
        }

        public override bool Equals(object obj) 
        {
            var entity = obj as Entity<TId>;

            return entity is not null ?
                this.Equals(entity) : base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public bool Equals(Entity<TId> other) 
        {
            return other is null ? false : Id.Equals(other.Id);
        }
    }
}
