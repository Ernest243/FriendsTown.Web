using FriendsTown.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsTown.Domain
{
    public class Event : Entity<Guid>
    {
        public Event(Guid id) : base(id)
        {
            Id = id;
        }

        public Friend Organizer { get; protected set; }
        public Activity ActivityType { get; protected set; }
        public Date Date { get; protected set; }
        public Place Place { get; protected set; }
        public List<Friend> Participants { get; protected set; }
        public List<Offer> Offers { get; protected set; }


        public void Update(Friend organizer, Activity activityType, Date date, Place place) 
        {
            Organizer = organizer;
            ActivityType = activityType;
            Date = date;
            Place = place;
        }

        public static Event Create(Guid id, Friend organizer, Activity activityType, Date date, Place place,
            List<string> offers)
        {
            Event theEvent = new Event(id);
            theEvent.Update(organizer, activityType, date, place);
            theEvent.Offers = offers.Select(o => Offer.Create(Guid.NewGuid(), theEvent, o)).ToList();

            return theEvent;
        }

        public void AddParticipant(Friend participant) 
        {
            Participants.Add(participant);
        }

        public void RemoveParticipant(Friend participant) 
        {
            if (Participants.Contains(participant)) 
            {
                Participants.Remove(participant);
            }
        }
    }
}
