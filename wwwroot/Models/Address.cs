using System;
using System.Runtime.CompilerServices;

namespace EfCoreExample.Models
{
    public class Address
    {
        public Address(string addressType, string street, string neighborhood, string city, string state, string zip)
        {
            AddressType = addressType;
            Street = street;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Zip = zip;
        }

        public string AddressType { get; private set; }
        public string Street { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Zip { get; private set; }
        
    }
}