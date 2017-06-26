using FinalTask.Data.Initialization;
using FinalTask.Data.Models;
using System.Data.Entity;

namespace FinalTask.Data
{
    public class MovieAppContext : DbContext
    {
        public MovieAppContext() : base("MovieAppDatabase")
        {
            Database.SetInitializer(new MovieAppDbInitialization());
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Hashtag> Hashtags { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieList> MovieLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasMany(x => x.MovieLists)
                .WithMany(x => x.Movies);

            modelBuilder.Entity<MovieList>()
                .HasMany(x => x.Movies)
                .WithMany(x => x.MovieLists);

            modelBuilder.Entity<Movie>()
                .HasRequired(x => x.Genre)
                .WithMany(x => x.Movies)
                .HasForeignKey(x => x.GenreId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Movie>()
                .HasRequired(x => x.Director)
                .WithMany(x => x.Movies)
                .HasForeignKey(x => x.DirectorId)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}
