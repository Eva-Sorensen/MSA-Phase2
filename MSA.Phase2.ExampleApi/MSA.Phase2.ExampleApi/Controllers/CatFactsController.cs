using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MSA.Phase2.ExampleApi.Controllers
{
    /// <summary />
    [Route("[controller]")]
    [ApiController]
    public class CatFactsController : ControllerBase
    {
        private readonly HttpClient _client;
        /// <summary />
        public CatFactsController(IHttpClientFactory clientFactory)
        {
            if (clientFactory is null)
            {
                throw new ArgumentNullException(nameof(clientFactory));
            }
            _client = clientFactory.CreateClient("catFacts");
        }
        /// <summary>
        /// Gets the raw JSON for the cat facts
        /// </summary>
        /// <returns>A JSON object representing the hot feed in reddit</returns>
        [HttpGet]
        [Route("raw")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetRawRedditHotPosts()
        {
            var res = await _client.GetAsync("/facts");
            var content = await res.Content.ReadAsStringAsync();
            return Ok(content);
        }
    }
}
