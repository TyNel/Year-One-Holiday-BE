using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YearOne.Models.Requests
{
    public class RecipeAddRequest
    {
        [Required]
        public int CookieType { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Url { get; set; }

        
        [StringLength(50, MinimumLength = 0)]
        public string Description { get; set; }
    }
}
