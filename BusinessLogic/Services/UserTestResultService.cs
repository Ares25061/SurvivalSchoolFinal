using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class UserTestResultService : IUserTestResultService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserTestResultService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<UserTestResult>> GetAll()
        {
            return await _repositoryWrapper.UserTestResult.FindAll();
        }

        public async Task<UserTestResult> GetById(int id)
        {
            var UserTestResult = await _repositoryWrapper.UserTestResult
                .FindByCondition(x => x.ResultId == id);
            if (UserTestResult is null || UserTestResult.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }
            return UserTestResult.First();
        }

        public async Task Create(UserTestResult model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (model.Score < 0)
            {
                throw new ArgumentException(nameof(model.Score));
            }
            await _repositoryWrapper.UserTestResult.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(UserTestResult model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (model.Score < 0)
            {
                throw new ArgumentException(nameof(model.Score));
            }
            if (model.CompletedDate > DateTime.Now)
            {
                throw new ArgumentException(nameof(model.CompletedDate));
            }
            await _repositoryWrapper.UserTestResult.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var UserTestResult = await _repositoryWrapper.UserTestResult
                .FindByCondition(x => x.ResultId == id);
            if (UserTestResult is null || UserTestResult.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }
            await _repositoryWrapper.UserTestResult.Delete(UserTestResult.First());
            await _repositoryWrapper.Save();
        }
    }
}