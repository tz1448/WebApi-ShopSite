using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RatingRervice : IRatingRervice
    {
        StoryDbContext _storyDbContext;
        IRatingRepository _ratingRepository;

        public RatingRervice(IRatingRepository ratingRepository)
        {
            
            _ratingRepository = ratingRepository;

        }


        public async Task<Rating> AddRating(Rating rating)
        {

            return await _ratingRepository.AddRating(rating);
        }
    }
}
