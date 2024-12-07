using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IVideoCommentsService
    {
        Task<List<VideoComment>> GetAll();
        Task<VideoComment> GetById(int id);
        Task Create(VideoComment model);
        Task Update(VideoComment model);
        Task Delete(int id);
    }
}