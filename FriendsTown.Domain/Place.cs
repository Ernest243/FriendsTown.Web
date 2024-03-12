using FriendsTown.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsTown.Domain
{
    public class Place : ValueObject<Place>
    {
        public string City { get; protected set; }
        public string Street { get; protected set; }
        public string Number { get; protected set; }
        public string Reference { get; protected set; }
        
        public Place() { }

        public static Place Create(string city, string street, string number, string reference) 
        {
            if (string.IsNullOrEmpty(city) || string.IsNullOrEmpty(street) || 
                string.IsNullOrEmpty(number)) 
            {
                throw new ArgumentException("You should provide City, Street and Number");
            }

            Place place = new Place 
            {
                City = city,
                Street = street,
                Number = number,
                Reference = reference
            };

            return place;
        }

        public override string ToString()
        {
            return $"City: {City}, Street: {Street}, Number: {Number} " +
                $"{(Reference == null ? "" : "Reference: ")} {Reference} ";
        }
    }
}
