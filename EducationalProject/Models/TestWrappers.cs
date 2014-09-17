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

    public class TestInfoWrapper
    {
        public int TestId { get; set; }
        public string TestName { get; set; }
        public int CountQuestions { get; set; }
    }

    public class QuestionInProgresWrapper
    {
        public string TestType{ get; set; }
        public string QuestionText{ get; set; }
        public int QuestionCount{ get; set; }
        public string SelectedAnswer { set; get; }
        public List<VariantItem> AnswerVariantList { get; set; }
    }

    public class VariantItem
    {
        public int VariantId { get; set; }
        public bool Selected { get; set; }
        public string Text { get; set; }
    }

    public class ResultsWrapper
    {
        public string TestName { get; set; }
        public DateTime? DatePassing { get; set; }
        public int? PercentTaken { get; set; }
        public bool? Passed { get; set; }
    }
}