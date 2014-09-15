using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationalProject.Models
{
    [Table("Test")]
    public class Test
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TestId { get; set; }
        public string TestName { get; set; }
        public string PathFile { get; set; }
        public DateTime? DateDownload { get; set; }
        public UserProfile User { get; set; }
        public string Order { get; set; }
        public List<Question> Questions { get; set; } 
    }

    [Table("Question")]
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public int? Number { get; set; }
        public string TestType { get; set; }
        public string Answer { get; set; }
    }

    [Table("QuestionWithVariants")]
    public class QuestionWithVariants : Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionWithVariantsId { get; set; }
        public List<VariantAnswer> VariantAnswers { get; set; }
    }

    [Table("VariantAnswer")]
    public class VariantAnswer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VariantAnswerId { get; set; }
        public string Text { get; set; }
    }
}