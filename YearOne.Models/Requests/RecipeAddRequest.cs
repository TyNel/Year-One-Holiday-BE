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
        [StringLength(50, MinimumLength = 1)]
        public string Url { get; set; }
    }
}
