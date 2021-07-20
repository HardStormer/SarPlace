using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GMD.SarPlace.Etities
{
    public class Place
    {
        public Guid ID { get; private set; }
        public DateTime PublicationDate { get; private set; }
        public Guid User_id { get; private set; }

        public string Title { get; set; }
        public string Text { get; set; }

        public List<Guid> Comments_id { get; set; }

        public Place(string title, string text, Guid user_id)
        {
            ID = Guid.NewGuid();
            PublicationDate = DateTime.Now;
            User_id = user_id;
            Title = title;
            Text = text;
        }
        public Place(Guid id, DateTime publicationDate, Guid user_id, string title, string text)
        {
            ID = id;
            PublicationDate = publicationDate;
            User_id = user_id;
            Title = title;
            Text = text;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
