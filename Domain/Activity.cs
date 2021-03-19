using System;

namespace Domain
{
    public class Activity // Properties are the columns in the DB for Activities Table
    {
        public Guid Id { get; set; } // EntityFramework recognizes this name "Id" as a Primary Key

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string City { get; set; }

        public string Venue { get; set; }
    }
}