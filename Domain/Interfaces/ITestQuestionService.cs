using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITestQuestionService
    {
        Task<List<TestQuestion>> GetAll();
        Task<TestQuestion> GetById(int id);
        Task Create(TestQuestion model);
        Task Update(TestQuestion model);
        Task Delete(int id);
    }
}