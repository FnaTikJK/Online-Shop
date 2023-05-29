using API.Infrastructure.Extensions;
using API.Modules.Search.Core;
using API.Modules.Search.DTO;
using API.Modules.Search.Ports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.Search
{
    [Route("back/api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [HttpGet]
        public async Task<ActionResult<SearchResponse>> SearchAsync([FromQuery] SearchRequest searchRequest)
        {
            var response = await searchService.SearchAsync(searchRequest);

            return response.IsSuccess ? Ok(response.Value)
                : BadRequest(response.Error);
        }

        [HttpGet("Auth")]
        [Authorize]
        public async Task<ActionResult<SearchResponse>> SearchAuthAsync([FromQuery] SearchRequest searchRequest)
        {
            var response = await searchService.SearchAuthAsync(Guid.Parse(User.GetId()), searchRequest);

            return response.IsSuccess ? Ok(response.Value)
                : BadRequest(response.Error);
        }

        [HttpGet("Filters")]
        public async Task<ActionResult<FiltersDTO>> GetFilters()
        {
            var response = await searchService.GetFilters();

            return response.IsSuccess ? 
                Ok(response.Value) : BadRequest(response.Error);
        }
    }
}
