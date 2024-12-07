using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess.Repositories
{
    public class NotificationsRepository : RepositoryBase<Notification>, INotificationsRepository
    {
        public NotificationsRepository(SurvivalSchool1234Context repositoryContext)
            : base(repositoryContext)
        {
        }

    }
}