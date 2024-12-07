using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class LectureComment
    {
        public LectureComment()
        {
            InverseParentComment = new HashSet<LectureComment>();
        }

        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int LectureId { get; set; }
        public string CommentText { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int? ParentCommentId { get; set; }

        public virtual Lecture Lecture { get; set; } = null!;
        public virtual LectureComment? ParentComment { get; set; }
        public virtual ICollection<LectureComment> InverseParentComment { get; set; }
    }
}