using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class VideoService : IVideoService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public VideoService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Video>> GetAll()
        {
            return await _repositoryWrapper.Video.FindAll();
        }

        public async Task<Video> GetById(int id)
        {
            var Video = await _repositoryWrapper.Video
                .FindByCondition(x => x.VideoId == id);
            if (Video is null || Video.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }
            return Video.First();
        }

        public async Task Create(Video model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.Title))
            {
                throw new ArgumentException(nameof(model.Title));
            }
            if (string.IsNullOrEmpty(model.Url))
            {
                throw new ArgumentException(nameof(model.Url));
            }
            await _repositoryWrapper.Video.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Video model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.Title))
            {
                throw new ArgumentException(nameof(model.Title));
            }
            if (string.IsNullOrEmpty(model.Url))
            {
                throw new ArgumentException(nameof(model.Url));
            }
            if (model.CreatedDate > DateTime.Now)
            {
                throw new ArgumentException(nameof(model.CreatedDate));
            }
            if (model.UpdatedDate > DateTime.Now)
            {
                throw new ArgumentException(nameof(model.CreatedDate));
            }
            await _repositoryWrapper.Video.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var Video = await _repositoryWrapper.Video
                .FindByCondition(x => x.VideoId == id);
            if (Video is null || Video.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }
            await _repositoryWrapper.Video.Delete(Video.First());
            await _repositoryWrapper.Save();
        }
    }
}