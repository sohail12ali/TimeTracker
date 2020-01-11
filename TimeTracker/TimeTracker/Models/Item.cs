using System;

namespace TimeTracker.Models
{
    public class Item : Realms.RealmObject
    {
        [Realms.PrimaryKey]
        public string Id { get; set; } = DateTime.Now.ToShortDateString();

        public DateTimeOffset InTime { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset OutTime { get; set; } = DateTimeOffset.Now;
        public string Description { get; set; } = DateTime.Now.ToLongDateString();
    }
}