using GraphQLLearn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLLearn.Repositores
{
    public interface IMovieRepository
    {
        Task<Movie> GetMovieByIdAsync(Guid id);
        Task<Movie> AddReviewToMovieAsync(Guid id, Review review);
    }
}
