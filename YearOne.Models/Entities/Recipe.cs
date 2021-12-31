using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YearOne.Models.Entities
{
    public class Recipe
    {
        public int RecipeId { get; set; }

        public int CookieType { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }
    }
}
