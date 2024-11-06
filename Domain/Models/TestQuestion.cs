using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class TestQuestion
    {
        public int QuestionId { get; set; }
        public int TestId { get; set; }
        public string QuestionText { get; set; } = null!;
        public string CorrectAnswer { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual Test Test { get; set; } = null!;
    }
}