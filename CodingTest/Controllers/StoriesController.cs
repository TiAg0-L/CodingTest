using CodingTest.Domain.Stories;
using CodingTest.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController : ControllerBase
    {
        private readonly IStories _stories;

        public StoriesController(IStories stories)
        {
            _stories = stories ?? throw new ArgumentNullException(nameof(stories));
        }

        public IEnumerable<StoryResponse> Get()
        {
            return _stories.Get20BestStories().Select(story => new StoryResponse(story));
        }
    }
}
