using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using YearOne.Models.Entities;
using YearOne.Models.Requests;

namespace Year_One.Services.Interfaces
{
    public interface ICookieService
    {
        Task<IEnumerable<FullCookie>> GetCookieTypes();

        Task<int> AddUser(UserAddRequest user);

        Task<User> Login(UserLogin loginRequest);
    }
}
