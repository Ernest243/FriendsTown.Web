using FriendsTown.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsTown.Domain
{
    public class Offer : Entity<Guid>
    {
        public Event Event { get; protected set; }
        public string Description { get; protected set; }

        public Offer(Guid id) : base(id)
        {
            Id = id;
        }

        public void Update(Event theEvent, string description) 
        {
            if (string.IsNullOrEmpty(description))
                throw new ArgumentException("Name is required");

            Event = theEvent;
            Description = description;
        }

        public static Offer Create(Guid id, Event theEvent, string description) 
        {
            Offer offer = new Offer(id);
            offer.Update(theEvent, description);

            return offer;
        }
    }
}
