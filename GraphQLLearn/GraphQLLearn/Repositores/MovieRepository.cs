using GraphQLLearn.Database;
using GraphQLLearn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLLearn.Repositores
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieContext _context;

        public MovieRepository(MovieContext movieContext)
        {
            _context = movieContext;
            _context.Database.EnsureCreated();
        }

        public async Task<Movie> AddReviewToMovieAsync(Guid id, Review review)
        {
            var movie = await _context.Movies.Where(m => m.Id == id).FirstOrDefaultAsync();
            movie.AddReview(review);
            await _context.SaveChangesAsync();

            return movie;
        }

        public Task<Movie> GetMovieByIdAsync(Guid id)
        {
            return _context.Movies.Where(m => m.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
