using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sitesweep.Models;
using sitesweep.Services;

namespace sitesweep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : Controller
    {
        private readonly ISiteRankingSearchService _siteRankingSearchService;
        public SearchController(ISiteRankingSearchService siteRankingSearchService)
        {
            _siteRankingSearchService = siteRankingSearchService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SearchCriteria searchCriteria)
        {
            var rankingList = await _siteRankingSearchService.LoopupRankedResults(searchCriteria);
            throw new Exception("Test global middleware");
            return Ok(rankingList);
        }
    }
}
