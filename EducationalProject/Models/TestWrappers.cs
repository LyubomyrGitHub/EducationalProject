using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.Expressions;

namespace EducationalProject.Models
{
    public class TestWrapper
    {
        public int TestId { get; set; }
        public string TestName { get; set; }
        public DateTime? DateDownload { get; set; }
        public String Order { get; set; }
    }
}