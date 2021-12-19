﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YearOne.Models.Entities
{
    public class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public DateTime DateAdded { get; set; }

    public DateTime DateModified { get; set; }
}
}
