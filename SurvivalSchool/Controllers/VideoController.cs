using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SurvivalSchool.Contracts.Video;

namespace SurvivalSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private IVideoService _videoService;
        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        /// <summary>
        /// Получение информации о всех видео
        /// </summary>
        /// <returns></returns>

        // GET api/<VideoController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _videoService.GetAll();
            return Ok(Dto.Adapt<List<GetVideoResponse>>());
        }

        /// <summary>
        /// Получение информации о видео по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<VideoController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Dto = await _videoService.GetById(id);
            return Ok(Dto.Adapt<GetVideoResponse>());
        }

        /// <summary>
        /// Создание нового видео
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "Title" : "string",
        ///        "Url" : "string",
        ///        "CategoryId": 1,
        ///        "CreatedBy": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="video">Видео</param>
        /// <returns></returns>

        // POST api/<VideoController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateVideoRequest video)
        {
            var Dto = video.Adapt<Video>();
            await _videoService.Create(Dto);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о видео
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "VideoId": 1,
        ///       "Title" : "string",
        ///       "Url" : "string",
        ///       "CategoryId": 1,
        ///       "CreatedBy": 1,
        ///       "CreatedDate": "2024-09-19T14:05:14.947Z",
        ///       "UpdatedDate": "2024-09-19T14:05:14.947Z"
        ///     }
        ///
        /// </remarks>
        /// <param name="video">Видео</param>
        /// <returns></returns>

        // PUT api/<VideoController>
        [HttpPut]
        public async Task<IActionResult> Update(GetVideoResponse video)
        {
            var Dto = video.Adapt<Video>();
            await _videoService.Update(Dto);
            return Ok();
        }

        /// <summary>
        /// Удаление видео
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<VideoController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _videoService.Delete(id);
            return Ok();
        }
    }
}