using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SurvivalSchool.Contracts.LectureComment;

namespace SurvivalSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LectureCommentsController : ControllerBase
    {
        private ILectureCommentsService _lectureCommentsService;
        public LectureCommentsController(ILectureCommentsService lectureCommentsService)
        {
            _lectureCommentsService = lectureCommentsService;
        }

        /// <summary>
        /// Получение информации о всех комментариях лекции
        /// </summary>
        /// <returns></returns>

        // GET api/<LectureCommentsController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _lectureCommentsService.GetAll();
            return Ok(Dto.Adapt<List<GetLectureCommentsResponse>>());
        }

        /// <summary>
        /// Получение информации о комментарии лекции по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<LectureCommentsController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Dto = await _lectureCommentsService.GetById(id);
            return Ok(Dto.Adapt<GetLectureCommentsResponse>());
        }

        /// <summary>
        /// Создание нового комментария лекции
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "UserId": 1,
        ///        "LectureId" : 1,
        ///        "ContentText" : "string",
        ///        "ParentCommentId" : 1
        ///     }
        ///
        /// </remarks>
        /// <param name="lectureComments">Комментарий лекции</param>
        /// <returns></returns>

        // POST api/<LectureCommentsController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateLectureCommentsRequest lectureComments)
        {
            var Dto = lectureComments.Adapt<LectureComment>();
            await _lectureCommentsService.Create(Dto);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о комментарии лекции
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "CommentId": 1,
        ///       "UserId": 1,
        ///       "LectureId" : 1,
        ///       "ContentText" : "string",
        ///       "CreatedDate": "2024-09-19T14:05:14.947Z",
        ///       "UpdatedDate": "2024-09-19T14:05:14.947Z",
        ///       "ParentCommentId" : 1
        ///     }
        ///
        /// </remarks>
        /// <param name="lectureComments">Комментарий лекции</param>
        /// <returns></returns>

        // PUT api/<LectureCommentsController>
        [HttpPut]
        public async Task<IActionResult> Update(GetLectureCommentsResponse lectureComments)
        {
            var Dto = lectureComments.Adapt<LectureComment>();
            await _lectureCommentsService.Update(Dto);
            return Ok();
        }

        /// <summary>
        /// Удаление комментария лекции
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<LectureCommentsController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _lectureCommentsService.Delete(id);
            return Ok();
        }
    }
}