using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ILectureCommentsService
    {
        Task<List<LectureComment>> GetAll();
        Task<LectureComment> GetById(int id);
        Task Create(LectureComment model);
        Task Update(LectureComment model);
        Task Delete(int id);
    }
}