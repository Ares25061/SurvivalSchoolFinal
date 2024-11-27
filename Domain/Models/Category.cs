using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Category
    {
        public Category()
        {
            Lectures = new HashSet<Lecture>();
            Videos = new HashSet<Video>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<Lecture> Lectures { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
    }
}
