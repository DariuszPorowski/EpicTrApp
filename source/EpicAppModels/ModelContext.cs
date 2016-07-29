using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EpicAppModels;

namespace EpicAppModels
{
    public class ModelContext : DbContext
    {
        public DbSet<Track> Tracks { get; set; }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<Venue> Venues { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Person> People { get; set; }

        public DbSet<PersonSession> AttendeeSession { get; set; }

    }
}
