using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SurvivalSchool.Contracts.VideoComment;

namespace SurvivalSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoCommentsController : ControllerBase
    {
        private IVideoCommentsService _videoCommentsService;
        public VideoCommentsController(IVideoCommentsService videoCommentsService)
        {
            _videoCommentsService = videoCommentsService;
        }

        /// <summary>
        /// Получение информации о всех комментариях видео
        /// </summary>
        /// <returns></returns>

        // GET api/<VideoCommentsController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _videoCommentsService.GetAll();
            return Ok(Dto.Adapt<List<GetVideoCommentsResponse>>());
        }

        /// <summary>
        /// Получение информации о комментарии видео по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<VideoCommentsController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Dto = await _videoCommentsService.GetById(id);
            return Ok(Dto.Adapt<GetVideoCommentsResponse>());
        }

        /// <summary>
        /// Создание нового комментария видео
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "UserId": 1,
        ///        "VideoId" : 1,
        ///        "ContentText" : "string",
        ///        "ParentCommentId" : 1
        ///     }
        ///
        /// </remarks>
        /// <param name="videoComments">Комментарий видео</param>
        /// <returns></returns>

        // POST api/<VideoCommentsController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateVideoCommentsRequest videoComments)
        {
            var Dto = videoComments.Adapt<VideoComment>();
            await _videoCommentsService.Create(Dto);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о комментарии видео
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "CommentId": 1,
        ///       "UserId": 1,
        ///       "VideoId" : 1,
        ///       "ContentText" : "string",
        ///       "CreatedDate": "2024-09-19T14:05:14.947Z",
        ///       "UpdatedDate": "2024-09-19T14:05:14.947Z",
        ///       "ParentCommentId" : 1
        ///     }
        ///
        /// </remarks>
        /// <param name="videoComments">Комментарий видео</param>
        /// <returns></returns>

        // PUT api/<VideoCommentsController>
        [HttpPut]
        public async Task<IActionResult> Update(GetVideoCommentsResponse videoComments)
        {
            var Dto = videoComments.Adapt<VideoComment>();
            await _videoCommentsService.Update(Dto);
            return Ok();
        }

        /// <summary>
        /// Удаление комментария видео
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<VideoCommentsController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _videoCommentsService.Delete(id);
            return Ok();
        }
    }
}