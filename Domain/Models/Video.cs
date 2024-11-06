using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Video
    {
        public int VideoId { get; set; }
        public string Title { get; set; } = null!;
        public string Url { get; set; } = null!;
        public int CategoryId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual User CreatedByNavigation { get; set; } = null!;
    }
}