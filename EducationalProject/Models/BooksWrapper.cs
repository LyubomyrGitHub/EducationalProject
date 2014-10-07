using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationalProject.Models
{
    public class BooksWrapper
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string BookSection { get; set; }
        public int BookId { get; set; }
        //   public List<string> Books { get; set; }
    }
}