﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace PhoneBooth.Models
{
    public class ContactsContext : DbContext
    {
        public ContactsContext() : base("name=ContactsContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<PhoneBooth.Models.Contact> Contacts { get; set; }
    }
}
