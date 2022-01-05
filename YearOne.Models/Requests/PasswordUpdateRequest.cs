using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YearOne.Models.Requests
{
    public class PasswordUpdateRequest
    {
        public int UserId { get; set; }

        public string Password { get; set; }
    }
}
