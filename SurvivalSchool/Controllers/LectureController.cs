using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SurvivalSchool.Contracts.Lecture;

namespace SurvivalSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LectureController : ControllerBase
    {
        private ILectureService _lectureService;
        public LectureController(ILectureService lectureService)
        {
            _lectureService = lectureService;
        }

        /// <summary>
        /// Получение информации о всех лекциях
        /// </summary>
        /// <returns></returns>

        // GET api/<LectureController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _lectureService.GetAll();
            return Ok(Dto.Adapt<List<GetLectureResponse>>());
        }

        /// <summary>
        /// Получение информации о лекции по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<LectureController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Dto = await _lectureService.GetById(id);
            return Ok(Dto.Adapt<GetLectureResponse>());
        }

        /// <summary>
        /// Создание новой лекции
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "Title" : "string",
        ///        "Content" : "string",
        ///        "CategoryId": 1,
        ///        "CreatedBy": 1,
        ///        "PhotoURL": "string"
        ///     }
        ///
        /// </remarks>
        /// <param name="lecture">Лекция</param>
        /// <returns></returns>

        // POST api/<LectureController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateLectureRequest lecture)
        {
            var Dto = lecture.Adapt<Lecture>();
            await _lectureService.Create(Dto);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о лекции
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "LectureId": 1,
        ///       "Title" : "string",
        ///       "Content" : "string",
        ///       "CategoryId": 1,
        ///       "CreatedBy": 1,
        ///       "CreatedDate": "2024-09-19T14:05:14.947Z",
        ///       "UpdatedDate": "2024-09-19T14:05:14.947Z",
        ///       "PhotoURL": "string",
        ///       "IsApproved": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="lecture">Лекция</param>
        /// <returns></returns>

        // PUT api/<LectureController>
        [HttpPut]
        public async Task<IActionResult> Update(GetLectureResponse lecture)
        {
            var Dto = lecture.Adapt<Lecture>();
            await _lectureService.Update(Dto);
            return Ok();
        }

        /// <summary>
        /// Удаление лекции
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<LectureController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _lectureService.Delete(id);
            return Ok();
        }
    }
}