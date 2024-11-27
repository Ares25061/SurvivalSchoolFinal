using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class ForumThread
    {
        public ForumThread()
        {
            ForumPosts = new HashSet<ForumPost>();
        }

        public int ThreadId { get; set; }
        public string Title { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual User CreatedByNavigation { get; set; } = null!;
        public virtual ICollection<ForumPost> ForumPosts { get; set; }
    }
}