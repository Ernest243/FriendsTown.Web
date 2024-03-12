using FriendsTown.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsTown.Domain
{
    public class Activity : Entity<Guid>
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }

        public Activity (Guid id) : base (id) 
        {
            Id = id;
        }

        public void Update(string name, string description) 
        {
            Name = name ?? throw new ArgumentException("Name is required");
            Description = description;
        }

        public static Activity Create(Guid id, string name, string description) 
        {
            Activity activity = new Activity (id);
            activity.Update(name, description);

            return activity;
        }
    }
}
