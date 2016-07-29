using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicAppModels
{
    public class Track
    {
        public int TrackId { get; set; }
        public string TrackName { get; set; }        
        public string TrackDescription { get; set; }
        public virtual ICollection<Session> TrackSessions { get; set; }
    }

    public class Session
    {
        public int SessionId { get; set; }
        public string SessionCode { get; set; }
        public string SessionName { get; set; }
        public string SessionDescription { get; set; }
        public virtual Track SessionTrack { get; set;}
        public virtual ICollection<Attendee> Attendees { get; set; }

        public virtual ICollection<Speaker> Speakers  { get; set; }

        public virtual Room SessionRoom { get; set; }

        public DateTime SessionTime { get; set; }


    }


    public class Venue
    {
        public int VenueId { get; set; }
        public string VenueName { get; set; }
        public virtual ICollection<Room> VenueRoom { get; set; }


    }

    public class Room
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public virtual  Venue VenueName { get; set; }

        public int RoomCapacity { get; set; }

    }

    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

    public class Attendee : Person
    {
        public bool isAttendee { get; set; }

    }

    public class Speaker : Person
    {

        public bool isSpeaker { get; set; }
    }

    public class PersonSession
    {
        public int PersonSessionId { get; set; }
        public virtual ICollection<Session> Session { get; set; }
        public virtual ICollection<Person> PeopleInvolved { get; set; }



    }

}
