using System;

namespace FriendsTown.Web.Models
{
    public class EventViewModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Activity { get; set; }
        public string Organizer { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Reference { get; set; }
    }
}