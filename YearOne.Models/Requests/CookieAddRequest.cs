using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YearOne.Models.Requests
{
    public class CookieAddRequest
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string CookieName { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string CookieImageUrl { get; set; }
    }
}
