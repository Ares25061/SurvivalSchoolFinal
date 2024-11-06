using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITestService
    {
        Task<List<Test>> GetAll();
        Task<Test> GetById(int id);
        Task Create(Test model);
        Task Update(Test model);
        Task Delete(int id);
    }
}