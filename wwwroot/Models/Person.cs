using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace EfCoreExample.Models
{
    public class Person
    {
        public Person(Guid personId, string fistName, string lastName, ICollection<Contact> contacts)
        {
            PersonId = personId;
            FistName = fistName;
            LastName = lastName;
            Contacts = contacts;
        }

        public Guid PersonId { get; private set; }
        public string FistName { get; private set; }
        public string LastName { get; private set; }
        public ICollection<Contact> Contacts { get; private set; }   
    }
}