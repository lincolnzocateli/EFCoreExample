using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace EfCoreExample.Models
{
    public class Contact
    {
        public Contact(Guid contactId, string name, string observation, Address address)
        {
            ContactId = contactId;
            Name = name;
            Observation = observation;
            Address = address;
        }

        public Guid ContactId { get; private set; }
        public string Name { get; private set; }
        public string Observation { get; private set; }
        public Person Person { get; private set; }
        public Address Address { get; private set; }
        
    }
}