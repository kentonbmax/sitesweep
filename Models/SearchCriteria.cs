using System.ComponentModel.DataAnnotations;
using sitesweep.Validators;

namespace sitesweep.Models
{
    public class SearchCriteria
    {
        [Required]
        public string SearchString {get; set;}
        
        [Required]
        [ValidateUrl]
        public string Url {get; set;}
    }
}