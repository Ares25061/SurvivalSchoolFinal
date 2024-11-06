using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class TestService : ITestService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public TestService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Test>> GetAll()
        {
            return await _repositoryWrapper.Test.FindAll();
        }

        public async Task<Test> GetById(int id)
        {
            var Test = await _repositoryWrapper.Test
                .FindByCondition(x => x.TestId == id);
            if (Test is null || Test.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }
            return Test.First();
        }

        public async Task Create(Test model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.Title))
            {
                throw new ArgumentException(nameof(model.Title));
            }
            if (string.IsNullOrEmpty(model.Description))
            {
                throw new ArgumentException(nameof(model.Description));
            }
            await _repositoryWrapper.Test.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Test model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.Title))
            {
                throw new ArgumentException(nameof(model.Title));
            }
            if (string.IsNullOrEmpty(model.Description))
            {
                throw new ArgumentException(nameof(model.Description));
            }
            if (model.CreatedDate > DateTime.Now)
            {
                throw new ArgumentException(nameof(model.CreatedDate));
            }
            if (model.UpdatedDate > DateTime.Now)
            {
                throw new ArgumentException(nameof(model.CreatedDate));
            }
            await _repositoryWrapper.Test.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var Test = await _repositoryWrapper.Test
                .FindByCondition(x => x.TestId == id);
            if (Test is null || Test.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }
            await _repositoryWrapper.Test.Delete(Test.First());
            await _repositoryWrapper.Save();
        }
    }
}