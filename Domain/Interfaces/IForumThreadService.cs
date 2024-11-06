using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IForumThreadService
    {
        Task<List<ForumThread>> GetAll();
        Task<ForumThread> GetById(int id);
        Task Create(ForumThread model);
        Task Update(ForumThread model);
        Task Delete(int id);
    }
}