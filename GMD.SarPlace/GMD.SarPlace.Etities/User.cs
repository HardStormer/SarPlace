using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GMD.SarPlace.Etities
{
    public class User
    {
        public Guid ID { get; private set; }
        public DateTime RegistrationDate { get; private set; }

        public string Name { get; private set; }
        public string Password { get; set; }

        public List<Place> Places { get; set; }
        public List<Comment> Comments { get; set; }

        public User(string name, string password)
        {
            ID = Guid.NewGuid();
            RegistrationDate = DateTime.Now;
            Name = name;
            Password = password;
            Places = null;
            Comments = null;
        }
        public User(Guid id, DateTime datetime, string name, string password)
        {
            ID = id;
            RegistrationDate = datetime;
            Name = name;
            Password = password;
            Places = null;
            Comments = null;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
