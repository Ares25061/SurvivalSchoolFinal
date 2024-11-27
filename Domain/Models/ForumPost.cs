using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class ForumPost
    {
        public int PostId { get; set; }
        public int ThreadId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual ForumThread Thread { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}