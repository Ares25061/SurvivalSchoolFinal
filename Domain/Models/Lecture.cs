using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Lecture
    {
        public int LectureId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public int CategoryId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string? PhotoUrl { get; set; }
        public bool IsApproved { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual User CreatedByNavigation { get; set; } = null!;
    }
}