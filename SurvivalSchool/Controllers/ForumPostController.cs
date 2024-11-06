using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SurvivalSchool.Contracts.ForumPost;

namespace SurvivalSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForumPostController : ControllerBase
    {
        private IForumPostService _forumpostService;
        public ForumPostController(IForumPostService forumpostService)
        {
            _forumpostService = forumpostService;
        }

        /// <summary>
        /// Получение информации о всех постах на формуе
        /// </summary>
        /// <returns></returns>

        // GET api/<ForumPostController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _forumpostService.GetAll();
            return Ok(Dto.Adapt<List<GetForumPostResponse>>());
        }

        /// <summary>
        /// Получение информации о посте по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<ForumPostController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Dto = await _forumpostService.GetById(id);
            return Ok(Dto.Adapt<GetForumPostResponse>());
        }

        /// <summary>
        /// Создание нового поста
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "ThreadId": 1,
        ///        "UserId" : 1,
        ///        "Content" : "string"
        ///     }
        ///
        /// </remarks>
        /// <param name="forumpost">Пост</param>
        /// <returns></returns>

        // POST api/<ForumPostController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateForumPostRequest forumpost)
        {
            var Dto = forumpost.Adapt<ForumPost>();
            await _forumpostService.Create(Dto);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о посте
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "PostId": 1,
        ///       "ThreadId": 1,
        ///       "UserId" : 1,
        ///       "Content" : "string",
        ///       "CreatedDate": "2024-09-19T14:05:14.947Z",
        ///       "UpdatedDate": "2024-09-19T14:05:14.947Z"
        ///     }
        ///
        /// </remarks>
        /// <param name="forumpost">Пост</param>
        /// <returns></returns>

        // PUT api/<ForumPostController>
        [HttpPut]
        public async Task<IActionResult> Update(GetForumPostResponse forumpost)
        {
            var Dto = forumpost.Adapt<ForumPost>();
            await _forumpostService.Update(Dto);
            return Ok();
        }

        /// <summary>
        /// Удаление поста
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<ForumPostController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _forumpostService.Delete(id);
            return Ok();
        }
    }
}