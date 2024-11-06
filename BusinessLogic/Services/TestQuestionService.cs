using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class TestQuestionService : ITestQuestionService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public TestQuestionService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<TestQuestion>> GetAll()
        {
            return await _repositoryWrapper.TestQuestion.FindAll();
        }

        public async Task<TestQuestion> GetById(int id)
        {
            var TestQuestion = await _repositoryWrapper.TestQuestion
                .FindByCondition(x => x.QuestionId == id);
            if (TestQuestion is null || TestQuestion.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }
            return TestQuestion.First();
        }

        public async Task Create(TestQuestion model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.QuestionText))
            {
                throw new ArgumentException(nameof(model.QuestionText));
            }
            if (string.IsNullOrEmpty(model.CorrectAnswer))
            {
                throw new ArgumentException(nameof(model.CorrectAnswer));
            }
            await _repositoryWrapper.TestQuestion.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(TestQuestion model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.QuestionText))
            {
                throw new ArgumentException(nameof(model.QuestionText));
            }
            if (string.IsNullOrEmpty(model.CorrectAnswer))
            {
                throw new ArgumentException(nameof(model.CorrectAnswer));
            }
            if (model.CreatedDate > DateTime.Now)
            {
                throw new ArgumentException(nameof(model.CreatedDate));
            }
            if (model.UpdatedDate > DateTime.Now)
            {
                throw new ArgumentException(nameof(model.CreatedDate));
            }
            await _repositoryWrapper.TestQuestion.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var TestQuestion = await _repositoryWrapper.TestQuestion
                .FindByCondition(x => x.QuestionId == id);
            if (TestQuestion is null || TestQuestion.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }
            await _repositoryWrapper.TestQuestion.Delete(TestQuestion.First());
            await _repositoryWrapper.Save();
        }
    }
}