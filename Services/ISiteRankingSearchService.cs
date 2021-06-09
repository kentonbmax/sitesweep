using System.Collections.Generic;
using System.Threading.Tasks;
using sitesweep.Models;


namespace sitesweep.Services
{
    public interface ISiteRankingSearchService
    {
        Task<RankedResults> LoopupRankedResults(SearchCriteria searchCriteria);
    }
}