using FriendsTown.Domain;
using System;
using System.Collections.Generic;

namespace FriendsTown.Data.Repositories
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();
        Event FindById(Guid id);
        void Add(Event newEvent);
    }
}