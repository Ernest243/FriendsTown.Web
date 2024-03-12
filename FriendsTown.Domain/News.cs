using FriendsTown.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsTown.Domain
{
    public class News : Entity<Guid>
    {
        public Date Date { get; protected set; }
        public Place Place { get; protected set; }
        public string Description { get; protected set; }

        public News(Guid id) : base(id) 
        {
            Id = id;
        }

        public void Update(Date date, Place place, string description) 
        {
            Description = description ?? throw new ArgumentException("Description is required");

            Date = date;
            Place = place;
        }

        public static News Create(Guid id, Date date, Place place, string description) 
        {
            News news = new News(id);
            news.Update(date, place, description);

            return news;
        }
    }
}
