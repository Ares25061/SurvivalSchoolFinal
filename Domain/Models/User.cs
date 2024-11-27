using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class User
    {
        public User()
        {
            ForumPosts = new HashSet<ForumPost>();
            ForumThreads = new HashSet<ForumThread>();
            Lectures = new HashSet<Lecture>();
            Tests = new HashSet<Test>();
            UserTestResults = new HashSet<UserTestResult>();
            Videos = new HashSet<Video>();
        }

        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Pass { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime RegistrationDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<ForumPost> ForumPosts { get; set; }
        public virtual ICollection<ForumThread> ForumThreads { get; set; }
        public virtual ICollection<Lecture> Lectures { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
        public virtual ICollection<UserTestResult> UserTestResults { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
    }
}
