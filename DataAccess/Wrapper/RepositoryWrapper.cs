using DataAccess.Repositories;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private SurvivalSchool1Context _repoContext;
        private IUserRepository _user;
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }
        private IForumPostRepository _forumpost;
        public IForumPostRepository ForumPost
        {
            get
            {
                if (_forumpost == null)
                {
                    _forumpost = new ForumPostRepository(_repoContext);
                }
                return _forumpost;
            }
        }
        private IForumThreadRepository _forumthread;
        public IForumThreadRepository ForumThread
        {
            get
            {
                if (_forumthread == null)
                {
                    _forumthread = new ForumThreadRepository(_repoContext);
                }
                return _forumthread;
            }
        }
        private ILectureRepository _lecture;
        public ILectureRepository Lecture
        {
            get
            {
                if (_lecture == null)
                {
                    _lecture = new LectureRepository(_repoContext);
                }
                return _lecture;
            }
        }
        private ITestRepository _test;
        public ITestRepository Test
        {
            get
            {
                if (_test == null)
                {
                    _test = new TestRepository(_repoContext);
                }
                return _test;
            }
        }
        private ITestQuestionRepository _testquestion;
        public ITestQuestionRepository TestQuestion
        {
            get
            {
                if (_testquestion == null)
                {
                    _testquestion = new TestQuestionRepository(_repoContext);
                }
                return _testquestion;
            }
        }
        private IUserTestResultRepository _usertestresult;
        public IUserTestResultRepository UserTestResult
        {
            get
            {
                if (_usertestresult == null)
                {
                    _usertestresult = new UserTestResultRepository(_repoContext);
                }
                return _usertestresult;
            }
        }
        private IVideoRepository _video;
        public IVideoRepository Video
        {
            get
            {
                if (_video == null)
                {
                    _video = new VideoRepository(_repoContext);
                }
                return _video;
            }
        }
        public RepositoryWrapper(SurvivalSchool1Context repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public async Task Save()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}