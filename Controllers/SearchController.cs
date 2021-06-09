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
            if (!ModelState.IsValid)
            {
                return new BadRequestResult();
            }
            var rankingList = await _siteRankingSearchService.LoopupRankedResults(searchCriteria);
            return Ok(rankingList);
        }
    }
}
