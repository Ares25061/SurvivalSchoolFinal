using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class LectureService : ILectureService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public LectureService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Lecture>> GetAll()
        {
            return await _repositoryWrapper.Lecture.FindAll();
        }

        public async Task<Lecture> GetById(int id)
        {
            var Lecture = await _repositoryWrapper.Lecture
                .FindByCondition(x => x.LectureId == id);
            if (Lecture is null || Lecture.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }
            return Lecture.First();
        }

        public async Task Create(Lecture model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.Title))
            {
                throw new ArgumentException(nameof(model.Title));
            }
            if (string.IsNullOrEmpty(model.Content))
            {
                throw new ArgumentException(nameof(model.Content));
            }
            await _repositoryWrapper.Lecture.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Lecture model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.Title))
            {
                throw new ArgumentException(nameof(model.Title));
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
            await _repositoryWrapper.Lecture.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var Lecture = await _repositoryWrapper.Lecture
                .FindByCondition(x => x.LectureId == id);
            if (Lecture is null || Lecture.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }
            await _repositoryWrapper.Lecture.Delete(Lecture.First());
            await _repositoryWrapper.Save();
        }
    }
}