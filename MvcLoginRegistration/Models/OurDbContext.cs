﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace MvcLoginRegistration.Models
{
    public class OurDbContext : DbContext
    {
        public DbSet<UAccount> uAccount { get; set; }

    }
}