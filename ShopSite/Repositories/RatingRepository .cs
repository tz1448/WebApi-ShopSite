using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repositories
{
    public class RatingRepository : IRatingRepository
    {


        StoryDbContext _storyDbContext;

        public RatingRepository(StoryDbContext storyDbContext)
        {
            _storyDbContext = storyDbContext;
        }


        public async Task<Rating> AddRating(Rating rating)
        {
            await _storyDbContext.Rating.AddAsync(rating);
            await _storyDbContext.SaveChangesAsync();
            return rating;
        }

    }
}
