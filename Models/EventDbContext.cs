using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_kolos.Models
{
    public class EventDbContext : DbContext
    {
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Artist_Event> Artist_Event { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Event_Organiser> Event_Organiser { get; set; }
        public DbSet<Organiser> Organiser { get; set; }

        public EventDbContext() { }
        public EventDbContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // relacja artist_Event
            modelBuilder.Entity<Artist_Event>().HasKey(e =>
            new
            {
                e.IdArtist,
                e.IdEvent
            });

            modelBuilder.Entity<Artist_Event>()
                .HasOne(e => e.Artist)
                .WithMany(e => e.Artist_Events)
                .HasForeignKey(e => e.IdArtist);
            
            modelBuilder.Entity<Artist_Event>()
                .HasOne(e => e.Event)
                .WithMany(e => e.Artist_Events)
                .HasForeignKey(e => e.IdEvent);

            // relacja Event_Organiser
            modelBuilder.Entity<Event_Organiser>().HasKey(e =>
            new
            {
                e.IdEvent,
                e.IdOrganiser
            });

            modelBuilder.Entity<Event_Organiser>()
                .HasOne(e => e.Event)
                .WithMany(e => e.Event_Organisers)
                .HasForeignKey(e => e.IdEvent);

            modelBuilder.Entity<Event_Organiser>()
                .HasOne(e => e.Organiser)
                .WithMany(e => e.Event_Organisers)
                .HasForeignKey(e => e.IdOrganiser);



        }
    }
}
