using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ForumThreadRepository : RepositoryBase<ForumThread>, IForumThreadRepository
    {
        public ForumThreadRepository(SurvivalSchool1234Context repositoryContext)
            : base(repositoryContext)
        {
        }

    }
}