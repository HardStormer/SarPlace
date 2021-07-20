using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GMD.SarPlace.Etities
{
    public class Comment
    {

        public Guid ID { get; private set; }
        public DateTime PublicationDate { get; private set; }

        public Guid User_id { get; private set; }
        public Guid Place_id { get; private set; }

        public string Text { get; set; }

        public Comment(Guid user_id, Guid place_id, string text)
        {
            ID = Guid.NewGuid();
            PublicationDate = DateTime.Now;
            User_id = user_id;
            Place_id = place_id;
            Text = text;
        }
        public Comment(Guid id, DateTime publicationDate, Guid user_id, Guid place_id, string text)
        {
            ID = id;
            PublicationDate = publicationDate;
            User_id = user_id;
            Place_id = place_id;
            Text = text;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
