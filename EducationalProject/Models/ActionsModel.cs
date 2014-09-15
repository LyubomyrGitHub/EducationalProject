using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationalProject.Models
{
    [Table("Action")]
    public class Action
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActionId { get; set; }
        public UserProfile User { get; set; }
        public Test Test { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DatePassing { get; set; }
        public int? TimeLimitPerQuestion { get; set; }
        public int? Status { get; set; }
        public DateTime? DateOpened { get; set; }
        public DateTime? DateClosed { get; set; }
    }

    [Table("TestResult")]
    public class TestResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TestResultId { get; set; }
        public Action Action { get; set; }
        public UserProfile User { get; set; }
        public Test Test { get; set; }
        public DateTime? DatePassing { get; set; }
        public int? PercentTaken { get; set; }
        public bool? Passed { get; set; }
    }

    [Table("TestInProgres")]
    public class TestInProgres
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TestInProgresId { get; set; }
        public Action Action { get; set; }
        public int? Number { get; set; }
        public Question Question { get; set; }
        public string UserAnswer { get; set; }
        public bool Submitted { get; set; }
    }

    [Table("TestHistory")]
    public class TestHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TestHistoryId { get; set; }
        public Action Action { get; set; }
        public int? Number { get; set; }
        public Question Question { get; set; }
        public string UserAnswer { get; set; }
    }
}