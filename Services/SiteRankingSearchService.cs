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
               var searchUrl = $"{searchCriteria.Url}/{searchCriteria.SearchString}";
               var response = await httpClient.GetAsync(searchUrl);

               if(response.IsSuccessStatusCode)
               {
                   var body = await response.Content.ReadAsStringAsync();
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