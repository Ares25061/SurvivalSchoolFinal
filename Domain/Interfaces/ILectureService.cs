using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ILectureService
    {
        Task<List<Lecture>> GetAll();
        Task<Lecture> GetById(int id);
        Task Create(Lecture model);
        Task Update(Lecture model);
        Task Delete(int id);
    }
}