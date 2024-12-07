using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SurvivalSchool.Contracts.Notification;

namespace SurvivalSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private INotificationsService _notificationsService;
        public NotificationsController(INotificationsService notificationsService)
        {
            _notificationsService = notificationsService;
        }

        /// <summary>
        /// Получение информации о всех уведомлениях
        /// </summary>
        /// <returns></returns>

        // GET api/<NotificationsController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _notificationsService.GetAll();
            return Ok(Dto.Adapt<List<GetNotificationsResponse>>());
        }

        /// <summary>
        /// Получение информации о уведомлениях по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<NotificationsController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Dto = await _notificationsService.GetById(id);
            return Ok(Dto.Adapt<GetNotificationsResponse>());
        }

        /// <summary>
        /// Создание нового уведомления
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "UserId": 1,
        ///        "NotificationType" : "string",
        ///        "NotificationText" : "string"
        ///     }
        ///
        /// </remarks>
        /// <param name="notifications">Уведомление</param>
        /// <returns></returns>

        // POST api/<NotificationsController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateNotificationsRequest notifications)
        {
            var Dto = notifications.Adapt<Notification>();
            await _notificationsService.Create(Dto);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о уведомлении
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "NotificationId": 1,
        ///       "UserId": 1,
        ///       "NotificationType" : "string",
        ///       "NotificationText" : "string",
        ///       "IsRead": 1,
        ///       "CreatedDate": "2024-09-19T14:05:14.947Z"
        ///     }
        ///
        /// </remarks>
        /// <param name="notifications">Уведомление</param>
        /// <returns></returns>

        // PUT api/<NotificationsController>
        [HttpPut]
        public async Task<IActionResult> Update(GetNotificationsResponse notifications)
        {
            var Dto = notifications.Adapt<Notification>();
            await _notificationsService.Update(Dto);
            return Ok();
        }

        /// <summary>
        /// Удаление уведомления
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<NotificationsController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _notificationsService.Delete(id);
            return Ok();
        }
    }
}