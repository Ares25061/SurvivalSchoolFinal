using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SurvivalSchool.Contracts.ForumThread;

namespace SurvivalSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForumThreadController : ControllerBase
    {
        private IForumThreadService _forumthreadService;
        public ForumThreadController(IForumThreadService forumthreadService)
        {
            _forumthreadService = forumthreadService;
        }

        /// <summary>
        /// Получение информации о всех тредах на формуе
        /// </summary>
        /// <returns></returns>

        // GET api/<ForumThreadController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _forumthreadService.GetAll();
            return Ok(Dto.Adapt<List<GetForumThreadResponse>>());
        }

        /// <summary>
        /// Получение информации о треде по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<ForumThreadController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Dto = await _forumthreadService.GetById(id);
            return Ok(Dto.Adapt<GetForumThreadResponse>());
        }

        /// <summary>
        /// Создание нового треда
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "Title" : "string",
        ///        "CreatedBy": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="forumthread">Тред</param>
        /// <returns></returns>

        // POST api/<ForumThreadController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateForumThreadRequest forumthread)
        {
            var Dto = forumthread.Adapt<ForumThread>();
            await _forumthreadService.Create(Dto);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о треде
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "ThreadId": 1,
        ///       "Title" : "string",
        ///       "CreatedBy": 1,
        ///       "CreatedDate": "2024-09-19T14:05:14.947Z",
        ///       "UpdatedDate": "2024-09-19T14:05:14.947Z"
        ///     }
        ///
        /// </remarks>
        /// <param name="forumthread">Тред</param>
        /// <returns></returns>

        // PUT api/<ForumThreadController>
        [HttpPut]
        public async Task<IActionResult> Update(GetForumThreadResponse forumthread)
        {
            var Dto = forumthread.Adapt<ForumThread>();
            await _forumthreadService.Update(Dto);
            return Ok();
        }

        /// <summary>
        /// Удаление треда
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<ForumThreadController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _forumthreadService.Delete(id);
            return Ok();
        }
    }
}