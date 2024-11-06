using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class UserTestResult
    {
        public int ResultId { get; set; }
        public int UserId { get; set; }
        public int TestId { get; set; }
        public int Score { get; set; }
        public DateTime CompletedDate { get; set; }

        public virtual Test Test { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}