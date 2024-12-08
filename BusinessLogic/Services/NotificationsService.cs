using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class NotificationsService : INotificationsService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public NotificationsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Notification>> GetAll()
        {
            return await _repositoryWrapper.Notifications.FindAll();
        }

        public async Task<Notification> GetById(int id)
        {
            var Notifications = await _repositoryWrapper.Notifications
                .FindByCondition(x => x.NotificationId == id);
            if (Notifications is null || Notifications.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }
            return Notifications.First();
        }

        public async Task Create(Notification model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.NotificationType))
            {
                throw new ArgumentException(nameof(model.NotificationType));
            }
            if (string.IsNullOrEmpty(model.NotificationText))
            {
                throw new ArgumentException(nameof(model.NotificationText));
            }

            await _repositoryWrapper.Notifications.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(Notification model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (string.IsNullOrEmpty(model.NotificationType))
            {
                throw new ArgumentException(nameof(model.NotificationType));
            }
            if (string.IsNullOrEmpty(model.NotificationText))
            {
                throw new ArgumentException(nameof(model.NotificationText));
            }
            if (model.CreatedDate > DateTime.Now)
            {
                throw new ArgumentException(nameof(model.CreatedDate));
            }
            await _repositoryWrapper.Notifications.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var Notifications = await _repositoryWrapper.Notifications
                .FindByCondition(x => x.NotificationId == id);
            if (Notifications is null || Notifications.Count == 0)
            {
                throw new ArgumentNullException("Not found");
            }
            await _repositoryWrapper.Notifications.Delete(Notifications.First());
            await _repositoryWrapper.Save();
        }
        public async Task Read(int id)
        {
            var Notifications = await GetById(id);
            if (Notifications == null)
            {
                throw new ArgumentNullException("Not found");
            }

            Notifications.IsRead = true;
            await Update(Notifications);
        }
    }
}