using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IVideoService
    {
        Task<List<Video>> GetAll();
        Task<Video> GetById(int id);
        Task Create(Video model);
        Task Update(Video model);
        Task Delete(int id);
    }
}