﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biddanondo.Models
{
    public class RestaurantModel
    {
        public int Id { get; set; }
        public string RestaurantName { get; set; }
        public string Location { get; set; }
        public string Password { get; set; }
    }
}