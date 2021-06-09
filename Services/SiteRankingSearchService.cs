using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using sitesweep.Models;
using sitesweep.Services;

namespace sitesweep.Services
{
    public class SiteRankingSearchService: ISiteRankingSearchService
    {
        private readonly HttpSearchClient _httpSearchClient;

        const string BASE_SEARCH_URL = "http://google.com/search?q=";
        public SiteRankingSearchService(HttpSearchClient httpSearchClient)
        {
            _httpSearchClient = httpSearchClient;
        }

        public async Task<RankedResults> LoopupRankedResults(SearchCriteria searchCriteria)
        {
            string rank = default;
            using(var httpClient = new HttpSearchClient())
            {
               var searchUrl = $"{BASE_SEARCH_URL}/{searchCriteria.Keywords}";
               var response = await httpClient.GetAsync(searchUrl);

               if(response.IsSuccessStatusCode)
               {
                   var content = await response.Content.ReadAsStringAsync();
                   rank = await ParseSiteOutputAndRank(content, searchCriteria.Url);
               } 
               else
               {
                   throw new System.Exception($"Unable to connect to {searchCriteria.Url}");
               }

               return new RankedResults
                    {
                        Url = searchCriteria.Url,
                        Keywords = searchCriteria.Keywords,
                        Rank = rank,
                        MatchCount = rank.Split(",").Length
                    };
            }
        }

        private async Task<string> ParseSiteOutputAndRank(string rawContent, string searchString)
        {
            const string QUERY_LINK_STRING = "/url?q=";

            int rankCounter = default;
            string result = default;

            if(string.IsNullOrWhiteSpace(rawContent))
            {
                throw new System.Exception("rawContent must be valid string");
            }
            await Task.Run( () => {
                var anchorStrs = GetLinkAnchorsFromHtml(rawContent);
                for(var i=0; i < anchorStrs.Length; i++)
                {
                    if(anchorStrs[i].Contains(QUERY_LINK_STRING))
                    {
                        if(anchorStrs[i].ToLowerInvariant().Contains(searchString.ToLower()))
                        {
                            rankCounter++;
                            result += rankCounter.ToString();
                        }
                    } 
                } 
            });
            return string.IsNullOrEmpty(result) ? "0" : result;
        }

        private string[] GetLinkAnchorsFromHtml(string content)
        {
            List<string> anchors = new List<string>();
            Regex regex = new Regex(@"<a href=(.|\n)*?<\/a>");
            var v = regex.Matches(content);
            foreach(var group in v)
            {
                anchors.Add(group.ToString());
            }
            return anchors.ToArray();
        }


        private string[] GetHtmlElemBlocks(string elem, string content)
        {
            List<string> anchors = new List<string>();
            Regex regex = new Regex(@$"<{elem}>(.|\n)*?<\/{elem}>");
            var v = regex.Matches(content);
            foreach(var group in v)
            {
                anchors.Add(group.ToString());
            }
            return anchors.ToArray();
        }
    }
}