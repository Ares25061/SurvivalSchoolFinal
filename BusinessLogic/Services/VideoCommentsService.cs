using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class VideoCommentService : IVideoCommentsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public VideoCommentService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<VideoComment>> GetAll()
        {
            return await _repositoryWrapper.VideoComments.FindAll();
        }

        public async Task<VideoComment> GetById(int id)
        {
            var VideoComment = await _repositoryWrapper.VideoComments
                .FindByCondition(x => x.CommentId == id);
            if (VideoComment is null || VideoComment.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }
            return VideoComment.First();
        }

        public async Task Create(VideoComment model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.CommentText))
            {
                throw new ArgumentException(nameof(model.CommentText));
            }
            await _repositoryWrapper.VideoComments.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(VideoComment model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.CommentText))
            {
                throw new ArgumentException(nameof(model.CommentText));
            }
            if (model.CreatedDate > DateTime.Now)
            {
                throw new ArgumentException(nameof(model.CreatedDate));
            }
            if (model.UpdatedDate > DateTime.Now)
            {
                throw new ArgumentException(nameof(model.CreatedDate));
            }
            await _repositoryWrapper.VideoComments.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var VideoComment = await _repositoryWrapper.VideoComments
                .FindByCondition(x => x.CommentId == id);
            if (VideoComment is null || VideoComment.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }
            await _repositoryWrapper.VideoComments.Delete(VideoComment.First());
            await _repositoryWrapper.Save();
        }
    }
}