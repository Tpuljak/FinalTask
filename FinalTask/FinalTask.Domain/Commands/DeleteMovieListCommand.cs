using FinalTask.Data;

namespace FinalTask.Domain.Commands
{
    public class DeleteMovieListCommand
    {
        private readonly MovieAppContext _context;

        public DeleteMovieListCommand()
        {
            _context = new MovieAppContext();
        }

        public void Execute(int id)
        {
            var movieListToDelete = _context.MovieLists.Find(id);
            if (movieListToDelete != null)
                _context.MovieLists.Remove(movieListToDelete);

            _context.SaveChanges();
        }
    }
}
