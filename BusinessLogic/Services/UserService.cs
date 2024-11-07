using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<User>> GetAll()
        {
            return await _repositoryWrapper.User.FindAll();
        }

        public async Task<User> GetById(int id)
        {
            var user = await _repositoryWrapper.User
                .FindByCondition(x => x.UserId == id);
            if (user is null || user.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }
            return user.First();
        }
        public async Task<User> GetByLogin(string login, string password)
        {
            var model = await _repositoryWrapper.User
                .FindByCondition(x => x.Username == login);
            if (model is null || model.Count == 0)
            {
                throw new ArgumentException("User not found");
            }
            if (model.First().Pass != password)
            {
                throw new ArgumentException("Password uncorrect");
            }
            return model.First();
        }

        public async Task Create(User model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.Username))
            {
                throw new ArgumentException(nameof(model.Username));
            }
            if (string.IsNullOrEmpty(model.Email))
            {
                throw new ArgumentException(nameof(model.Email));
            }
            if (string.IsNullOrEmpty(model.Pass))
            {
                throw new ArgumentException(nameof(model.Pass));
            }
            if (string.IsNullOrEmpty(model.FirstName))
            {
                throw new ArgumentException(nameof(model.FirstName));
            }
            if (string.IsNullOrEmpty(model.LastName))
            {
                throw new ArgumentException(nameof(model.LastName));
            }
            await _repositoryWrapper.User.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(User model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.Username))
            {
                throw new ArgumentException(nameof(model.Username));
            }
            if (string.IsNullOrEmpty(model.Email))
            {
                throw new ArgumentException(nameof(model.Email));
            }
            if (string.IsNullOrEmpty(model.Pass))
            {
                throw new ArgumentException(nameof(model.Pass));
            }
            if (string.IsNullOrEmpty(model.FirstName))
            {
                throw new ArgumentException(nameof(model.FirstName));
            }
            if (string.IsNullOrEmpty(model.LastName))
            {
                throw new ArgumentException(nameof(model.LastName));
            }
            if (model.RegistrationDate > DateTime.Now)
            {
                throw new ArgumentException(nameof(model.RegistrationDate));
            }
            await _repositoryWrapper.User.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.User
                .FindByCondition(x => x.UserId == id);
            if (user is null || user.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }
            await _repositoryWrapper.User.Delete(user.First());
            await _repositoryWrapper.Save();
        }
    }
}