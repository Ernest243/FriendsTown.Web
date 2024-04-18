using FriendsTown.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsTown.Data.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly FriendsTownContext _context;

        public ActivityRepository(FriendsTownContext context) 
        {
            _context = context;
        }

        public void Add(Activity activity) 
        {
            _context.Add(activity);
            _context.SaveChanges();
        }

        public Activity FindById(Guid id) 
        {
            return _context.Activities.Find(id);
        }

        public void Delete(Guid id) 
        {
            var activity = _context.Activities.Find(id);

            _context.Activities.Remove(activity);
            _context.SaveChanges();
        }

        public IEnumerable<Activity> GetAll() 
        {
            return _context.Activities.OrderBy(a => a.Name);
        }

        public void Update(Activity activity) 
        {
            _context.Entry(activity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
