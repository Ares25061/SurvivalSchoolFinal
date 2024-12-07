using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class LectureCommentService : ILectureCommentsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public LectureCommentService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<LectureComment>> GetAll()
        {
            return await _repositoryWrapper.LectureComments.FindAll();
        }

        public async Task<LectureComment> GetById(int id)
        {
            var LectureComment = await _repositoryWrapper.LectureComments
                .FindByCondition(x => x.CommentId == id);
            if (LectureComment is null || LectureComment.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }
            return LectureComment.First();
        }

        public async Task Create(LectureComment model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.CommentText))
            {
                throw new ArgumentException(nameof(model.CommentText));
            }
            await _repositoryWrapper.LectureComments.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(LectureComment model)
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
            await _repositoryWrapper.LectureComments.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var LectureComment = await _repositoryWrapper.LectureComments
                .FindByCondition(x => x.CommentId == id);
            if (LectureComment is null || LectureComment.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }
            await _repositoryWrapper.LectureComments.Delete(LectureComment.First());
            await _repositoryWrapper.Save();
        }
    }
}