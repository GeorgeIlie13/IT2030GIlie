using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EventApplication.Models
{
    public class SampleData : DropCreateDatabaseAlways<EventApplicationDb>
    {
        protected override void Seed(EventApplicationDb context)
        {
            var eventtypes = new List<EventType>
            {
                new EventType{Type = "Sport" },
                new EventType{Type = "Dance" },
                new EventType{Type = "Cooking" },
                new EventType{Type = "Modeling" },
                new EventType{Type = "Showroom" },
                new EventType{Type = "Play" },
                new EventType{Type = "Conference" },
                new EventType{Type = "Political" },
                new EventType{Type = "Circus" },
                new EventType{Type = "Theatre" },
               

            };

            new List<Event> {
                    new Event{ EventType = eventtypes.Single(e => e.Type == "Sport"), Title = "Sport Event", AvailableTickets = 100, Description = "Visit the Sports Event", StartDate = new DateTime(2018, 5, 17), EndDate = new DateTime(2018, 5, 17), MaxTickets = 100, Organizer = "Sports", OrganizerContactInfo = "444-333-1221", City = "Las Vegas", State = "Nevada"},
                    new Event{ EventType = eventtypes.Single(e => e.Type == "Sport"), Title = "Sport Event 1", AvailableTickets = 100, Description = "Visit the Sports Event 1", StartDate = new DateTime(2018, 6, 17), EndDate = new DateTime(2018, 6, 17), MaxTickets = 100, Organizer = "Sports", OrganizerContactInfo = "444-333-1221", City = "Las Vegas", State = "Nevada"},
                    new Event{ EventType = eventtypes.Single(e => e.Type == "Sport"), Title = "Sport Event 2", AvailableTickets = 100, Description = "Visit the Sports Event 2", StartDate = new DateTime(2018, 5, 18), EndDate = new DateTime(2018, 5, 18), MaxTickets = 100, Organizer = "Sports", OrganizerContactInfo = "216-332-3231", City = "Cleveland", State = "Ohio"},
                    new Event{ EventType = eventtypes.Single(e => e.Type == "Dance"), Title = "Dance Event", AvailableTickets = 100, Description = "Visit the Dance Event", StartDate = new DateTime(2018, 5, 1), EndDate = new DateTime(2018, 5, 1), MaxTickets = 100, Organizer = "Dance", OrganizerContactInfo = "216-456-0000", City = "Cleveland", State = "Ohio"},
                    new Event{ EventType = eventtypes.Single(e => e.Type == "Dance"), Title = "Dance Event 1", AvailableTickets = 100, Description = "Visit the Dance Event 1", StartDate = new DateTime(2018, 5, 2), EndDate = new DateTime(2018, 5, 2), MaxTickets = 100, Organizer = "Dance", OrganizerContactInfo = "333-333-1221", City = "Las Vegas", State = "Nevada"},
                    new Event{ EventType = eventtypes.Single(e => e.Type == "Dance"), Title = "Dance Event 2", AvailableTickets = 100, Description = "Visit the Dance Event 2", StartDate = new DateTime(2019, 5, 3), EndDate = new DateTime(2019, 5, 3), MaxTickets = 100, Organizer = "Dance", OrganizerContactInfo = "216-332-3231", City = "Cleveland", State = "Ohio"},
                    new Event{ EventType = eventtypes.Single(e => e.Type == "Cooking"), Title = "Cooking Event", AvailableTickets = 100, Description = "Visit the Cooking Event", StartDate = new DateTime(2019, 5, 3), EndDate = new DateTime(2019, 5, 3), MaxTickets = 100, Organizer = "Cooking", OrganizerContactInfo = "216-456-0000", City = "Cleveland", State = "Ohio"},
                    new Event{ EventType = eventtypes.Single(e => e.Type == "Cooking"), Title = "Cooking Event 1", AvailableTickets = 100, Description = "Visit the Cooking Event 1", StartDate = new DateTime(2019, 5, 5), EndDate = new DateTime(2019, 5, 6), MaxTickets = 100, Organizer = "Cooking", OrganizerContactInfo = "444-565-1221", City = "Las Vegas", State = "Nevada"},
                    new Event{ EventType = eventtypes.Single(e => e.Type == "Cooking"), Title = "Cooking Event 2", AvailableTickets = 100, Description = "Visit the Cooking Event 2", StartDate = new DateTime(2019, 5, 5), EndDate = new DateTime(2019, 5, 7), MaxTickets = 100, Organizer = "Cooking", OrganizerContactInfo = "216-332-3231", City = "Cleveland", State = "Ohio"},
                    new Event{ EventType = eventtypes.Single(e => e.Type == "Modeling"), Title = "Modeling Event", AvailableTickets = 100, Description = "Visit the Modeling Event", StartDate = new DateTime(2019, 5, 1), EndDate = new DateTime(2019, 5, 2), MaxTickets = 100, Organizer = "Modeling", OrganizerContactInfo = "216-456-0000", City = "Cleveland", State = "Ohio"},
                    new Event{ EventType = eventtypes.Single(e => e.Type == "Modeling"), Title = "Modeling Event 1", AvailableTickets = 100, Description = "Visit the Modeling Event 1", StartDate = new DateTime(2019, 5, 1), EndDate = new DateTime(2019, 5, 2), MaxTickets = 100, Organizer = "Modeling", OrganizerContactInfo = "444-999-1201", City = "Las Vegas", State = "Nevada"},
                    new Event{ EventType = eventtypes.Single(e => e.Type == "Modeling"), Title = "Modeling Event 2", AvailableTickets = 100, Description = "Visit the Modeling Event 2", StartDate = new DateTime(2019, 5, 2), EndDate = new DateTime(2019, 5, 2), MaxTickets = 100, Organizer = "Modeling", OrganizerContactInfo = "216-356-3231", City = "Cleveland", State = "Ohio"},
                    new Event{ EventType = eventtypes.Single(e => e.Type == "Showroom"), Title = "Showroom Event", AvailableTickets = 100, Description = "Visit Showroom Event", StartDate = new DateTime(2019, 5, 20), EndDate = new DateTime(2019, 6, 20), MaxTickets = 100, Organizer = "Showroom", OrganizerContactInfo = "216-456-0000", City = "Akron", State = "Ohio"},
                    new Event{ EventType = eventtypes.Single(e => e.Type == "Showroom"), Title = "Showroom Event 1", AvailableTickets = 100, Description = "Visit Showroom Event 1", StartDate = new DateTime(2019, 5, 2), EndDate = new DateTime(2019, 5, 2), MaxTickets = 100, Organizer = "Showroom", OrganizerContactInfo = "442-314-1421", City = "Las Vegas", State = "Nevada"},
                    new Event{ EventType = eventtypes.Single(e => e.Type == "Showroom"), Title = "Showroom Event 2", AvailableTickets = 100, Description = "Visit Showroom Event 2", StartDate = new DateTime(2018, 6, 28), EndDate = new DateTime(2019, 6, 28), MaxTickets = 100, Organizer = "Showroom", OrganizerContactInfo = "216-332-3231", City = "Cleveland", State = "Ohio"},
                    new Event{ EventType = eventtypes.Single(e => e.Type == "Play"), Title = "Play Event", AvailableTickets = 100, Description = "Visit Play Event", StartDate = new DateTime(2019, 10, 19), EndDate = new DateTime(2019, 10, 19), MaxTickets = 100, Organizer = "Play Organizer", OrganizerContactInfo = "216-456-0000", City = "Akron", State = "Ohio"},
                    new Event{ EventType = eventtypes.Single(e => e.Type == "Play"), Title = "Play Event 1", AvailableTickets = 100, Description = "Visit Play Event 1", StartDate = new DateTime(2019, 10, 10), EndDate = new DateTime(2019, 10, 10), MaxTickets = 100, Organizer = "Play Organizer", OrganizerContactInfo = "434-353-1621", City = "Las Vegas", State = "Nevada"},
                    new Event{ EventType = eventtypes.Single(e => e.Type == "Play"), Title = "Play Event 2", AvailableTickets = 100, Description = "Visit Play Event 2", StartDate = new DateTime(2019, 8, 10), EndDate = new DateTime(2019, 8, 10), MaxTickets = 100, Organizer = "Play Organizer", OrganizerContactInfo = "216-323-6431", City = "Cleveland", State = "Ohio"},
                    new Event{ EventType = eventtypes.Single(e => e.Type == "Conference"), Title = "Conference Event", AvailableTickets = 100, Description = "Visit Conference Event", StartDate = new DateTime(2019, 7, 3), EndDate = new DateTime(2019, 7, 3), MaxTickets = 100, Organizer = "Conference Organizer", OrganizerContactInfo = "216-456-0000", City = "Cleveland", State = "Ohio"},
                    new Event{ EventType = eventtypes.Single(e => e.Type == "Conference"), Title = "Conference Event 1", AvailableTickets = 100, Description = "Visit Conference Event 1", StartDate = new DateTime(2019, 10, 10), EndDate = new DateTime(2019, 10, 10), MaxTickets = 100, Organizer = "Conference Organizer", OrganizerContactInfo = "440-333-1221", City = "Las Vegas", State = "Nevada"},
                    new Event{ EventType = eventtypes.Single(e => e.Type == "Conference"), Title = "Conference Event 2", AvailableTickets = 100, Description = "Visit Conference Event 2", StartDate = new DateTime(2019, 5, 1), EndDate = new DateTime(2019, 5, 1), MaxTickets = 100, Organizer = "Conference Organizer", OrganizerContactInfo = "216-332-3231", City = "Cleveland", State = "Ohio"},
                    new Event{ EventType = eventtypes.Single(e => e.Type == "Political"), Title = "Political Event", AvailableTickets = 100, Description = "Visit Political Event", StartDate = new DateTime(2019, 11, 1), EndDate = new DateTime(2019, 11, 1), MaxTickets = 100, Organizer = "Political", OrganizerContactInfo = "216-456-0000", City = "Cleveland", State = "Ohio"},
                    new Event{ EventType = eventtypes.Single(e => e.Type == "Political"), Title = "Political Event 1", AvailableTickets = 100, Description = "Visit Political Event 1", StartDate = new DateTime(2019, 10, 10), EndDate = new DateTime(2019, 10, 10), MaxTickets = 100, Organizer = "Political", OrganizerContactInfo = "444-333-9897", City = "Fort Wayne", State = "Indiana"},
                    new Event{ EventType = eventtypes.Single(e => e.Type == "Political"), Title = "Political Event 2", AvailableTickets = 100, Description = "Visit Political Event 2", StartDate = new DateTime(2019, 11, 10), EndDate = new DateTime(2019, 11, 10), MaxTickets = 100, Organizer = "Political", OrganizerContactInfo = "216-564-3231", City = "Cleveland", State = "Ohio"},
                    new Event{ EventType = eventtypes.Single(e => e.Type == "Circus"), Title = "Circus Event", AvailableTickets = 100, Description = "Visit Circus Event", StartDate = new DateTime(2020, 3, 1), EndDate = new DateTime(2020, 3, 2), MaxTickets = 100, Organizer = "Circus", OrganizerContactInfo = "216-456-0000", City = "Toledo", State = "Ohio"},
                    new Event{ EventType = eventtypes.Single(e => e.Type == "Circus"), Title = "Circus Event 1", AvailableTickets = 100, Description = "Visit Circus Event 1", StartDate = new DateTime(2019, 5, 10), EndDate = new DateTime(2019, 5, 10), MaxTickets = 100, Organizer = "Circus", OrganizerContactInfo = "444-333-0000", City = "Fort Wayne", State = "Indiana"},
                    new Event{ EventType = eventtypes.Single(e => e.Type == "Circus"), Title = "Circus Event 2", AvailableTickets = 100, Description = "Visit Circus Event 2", StartDate = new DateTime(2020, 1, 10), EndDate = new DateTime(2020, 2, 10), MaxTickets = 100, Organizer = "Circus", OrganizerContactInfo = "216-777-3231", City = "Cleveland", State = "Ohio"},
                    new Event{ EventType = eventtypes.Single(e => e.Type == "Theatre"), Title = "Theatre Event", AvailableTickets = 100, Description = "Visit Theatre Event", StartDate = new DateTime(2020, 2, 1), EndDate = new DateTime(2020, 3, 3), MaxTickets = 100, Organizer = "Theatre", OrganizerContactInfo = "216-136-0000", City = "Columbus", State = "Ohio"},
                    new Event{ EventType = eventtypes.Single(e => e.Type == "Theatre"), Title = "Theatre Event 1", AvailableTickets = 100, Description = "Visit Theatre Event 1", StartDate = new DateTime(2020, 1, 10), EndDate = new DateTime(2020, 1, 10), MaxTickets = 100, Organizer = "Theatre", OrganizerContactInfo = "444-333-1601", City = "Gary", State = "Indiana"},
                    new Event{ EventType = eventtypes.Single(e => e.Type == "Theatre"), Title = "Theatre Event 2", AvailableTickets = 100, Description = "Visit Theatre Event 2", StartDate = new DateTime(2020, 5, 10), EndDate = new DateTime(2020, 5, 10), MaxTickets = 100, Organizer = "Theatre", OrganizerContactInfo = "216-377-3231", City = "Columbus", State = "Ohio"},

            }.ForEach(a => context.Events.Add(a));
        }

    }
}