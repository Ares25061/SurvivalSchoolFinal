using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Test
    {
        public Test()
        {
            TestQuestions = new HashSet<TestQuestion>();
            UserTestResults = new HashSet<UserTestResult>();
        }

        public int TestId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual User CreatedByNavigation { get; set; } = null!;
        public virtual ICollection<TestQuestion> TestQuestions { get; set; }
        public virtual ICollection<UserTestResult> UserTestResults { get; set; }
    }
}