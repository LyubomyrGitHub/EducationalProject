using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EducationalProject.Models
{
    public class EducationalProjectContext: DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
    }
}