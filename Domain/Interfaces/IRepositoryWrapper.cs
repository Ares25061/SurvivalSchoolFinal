using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces;

public interface IRepositoryWrapper
{
    IUserRepository User { get; }
    IForumPostRepository ForumPost { get; }
    IForumThreadRepository ForumThread { get; }
    ILectureRepository Lecture { get; }
    ITestQuestionRepository TestQuestion { get; }
    ITestRepository Test { get; }
    IUserTestResultRepository UserTestResult { get; }
    IVideoRepository Video { get; }
    Task Save();
}