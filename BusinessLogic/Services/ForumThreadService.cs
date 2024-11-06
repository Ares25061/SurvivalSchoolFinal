using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class ForumThreadService : IForumThreadService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ForumThreadService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<ForumThread>> GetAll()
        {
            return await _repositoryWrapper.ForumThread.FindAll();
        }

        public async Task<ForumThread> GetById(int id)
        {
            var ForumThread = await _repositoryWrapper.ForumThread
                .FindByCondition(x => x.ThreadId == id);
            if (ForumThread is null || ForumThread.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }
            return ForumThread.First();
        }

        public async Task Create(ForumThread model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.Title))
            {
                throw new ArgumentException(nameof(model.Title));
            }
            await _repositoryWrapper.ForumThread.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(ForumThread model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.Title))
            {
                throw new ArgumentException(nameof(model.Title));
            }
            if (model.CreatedDate > DateTime.Now)
            {
                throw new ArgumentException(nameof(model.CreatedDate));
            }
            if (model.UpdatedDate > DateTime.Now)
            {
                throw new ArgumentException(nameof(model.CreatedDate));
            }
            await _repositoryWrapper.ForumThread.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var ForumThread = await _repositoryWrapper.ForumThread
                .FindByCondition(x => x.ThreadId == id);
            if (ForumThread is null || ForumThread.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }
            await _repositoryWrapper.ForumThread.Delete(ForumThread.First());
            await _repositoryWrapper.Save();
        }
    }
}