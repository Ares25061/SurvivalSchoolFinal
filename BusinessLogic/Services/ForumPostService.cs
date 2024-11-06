using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class ForumPostService : IForumPostService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ForumPostService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<ForumPost>> GetAll()
        {
            return await _repositoryWrapper.ForumPost.FindAll();
        }

        public async Task<ForumPost> GetById(int id)
        {
            var ForumPost = await _repositoryWrapper.ForumPost
                .FindByCondition(x => x.PostId == id);
            if (ForumPost is null || ForumPost.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }
            return ForumPost.First();
        }

        public async Task Create(ForumPost model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.Content))
            {
                throw new ArgumentException(nameof(model.Content));
            }
            await _repositoryWrapper.ForumPost.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(ForumPost model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.Content))
            {
                throw new ArgumentException(nameof(model.Content));
            }
            if (model.CreatedDate > DateTime.Now)
            {
                throw new ArgumentException(nameof(model.CreatedDate));
            }
            if (model.UpdatedDate > DateTime.Now)
            {
                throw new ArgumentException(nameof(model.CreatedDate));
            }
            await _repositoryWrapper.ForumPost.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var ForumPost = await _repositoryWrapper.ForumPost
                .FindByCondition(x => x.PostId == id);
            if (ForumPost is null || ForumPost.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }
            await _repositoryWrapper.ForumPost.Delete(ForumPost.First());
            await _repositoryWrapper.Save();
        }
    }
}