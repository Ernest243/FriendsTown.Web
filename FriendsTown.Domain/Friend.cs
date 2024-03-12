using FriendsTown.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsTown.Domain
{
    public class Friend : Entity<Guid>
    {
        public string Name { get; protected set; }
        public string Phone { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }

        public Friend(Guid id) : base(id) 
        {
            Id = id;
        }


        public void Update(string name, string phone, string email, string password) 
        {
            Name = name ?? throw new ArgumentException("Name is required");
            Phone = phone;
            Email = email ?? throw new ArgumentException("Email is required");
            Password = password ?? throw new ArgumentException("Password is required");
        }

        public static Friend Create (Guid id, string name, string phone, string email, string password) 
        {
            Friend amigo = new Friend(id);

            amigo.Update(name, phone, email, password);

            return amigo;
        }

        public bool HasPhone => !string.IsNullOrEmpty(Phone);
    }
}
