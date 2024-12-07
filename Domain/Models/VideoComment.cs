using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class VideoComment
    {
        public VideoComment()
        {
            InverseParentComment = new HashSet<VideoComment>();
        }

        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int VideoId { get; set; }
        public string CommentText { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int? ParentCommentId { get; set; }

        public virtual VideoComment? ParentComment { get; set; }
        public virtual Video Video { get; set; } = null!;
        public virtual ICollection<VideoComment> InverseParentComment { get; set; }
    }
}