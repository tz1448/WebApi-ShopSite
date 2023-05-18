using Entities;

namespace Services
{
    public interface IRatingRervice
    {
        Task<Rating> AddRating(Rating rating);
    }
}