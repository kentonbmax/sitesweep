using System.Collections.Generic;
using System.Threading.Tasks;
using sitesweep.Models;
using sitesweep.Services;

namespace sitesweep.Services
{
    public class SiteRankingSearchService: ISiteRankingSearchService
    {
        private readonly HttpSearchClient _httpSearchClient;
        public SiteRankingSearchService(HttpSearchClient httpSearchClient)
        {
            _httpSearchClient = httpSearchClient;
        }

        public async Task<List<RankedResults>> LoopupRankedResults(SearchCriteria searchCriteria)
        {
            List<RankedResults> rankedResults = new List<RankedResults>();
            using(var httpClient = new HttpSearchClient())
            {
               var result = await httpClient.GetAsync(searchCriteria.Url);

               if(result.IsSuccessStatusCode)
               {
                   var body = result;
               } 
               else
               {
                   throw new System.Exception($"Unable to connect to {searchCriteria.Url}");
               }

               return rankedResults;
            }
        }

        /* private async Task<int[]> ParseSiteOutputAndRank()
        {
            Task.Run( () => {

            });
        } */
    }
}