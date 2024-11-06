using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SurvivalSchool.Contracts.TestQuestion;

namespace SurvivalSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestQuestionController : ControllerBase
    {
        private ITestQuestionService _testquestionService;
        public TestQuestionController(ITestQuestionService testquestionService)
        {
            _testquestionService = testquestionService;
        }

        /// <summary>
        /// Получение информации о всех вопросах в тестах
        /// </summary>
        /// <returns></returns>

        // GET api/<TestQuestionController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _testquestionService.GetAll();
            return Ok(Dto.Adapt<List<GetTestQuestionResponse>>());
        }

        /// <summary>
        /// Получение информации о вопросе в тесте по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<TestQuestionController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Dto = await _testquestionService.GetById(id);
            return Ok(Dto.Adapt<GetTestQuestionResponse>());
        }

        /// <summary>
        /// Создание нового вопрса в тесте
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "TestId": 1,
        ///        "QuestionText" : "string",
        ///        "CorrectAnswer" : "string"
        ///     }
        ///
        /// </remarks>
        /// <param name="testquestion">Вопрос в тесте</param>
        /// <returns></returns>

        // POST api/<TestQuestionController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateTestQuestionRequest testquestion)
        {
            var Dto = testquestion.Adapt<TestQuestion>();
            await _testquestionService.Create(Dto);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о вопросе в тесте
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "QuestionId": 1,
        ///       "TestId": 1,
        ///       "QuestionText" : "string",
        ///       "CorrectAnswer" : "string",
        ///       "CreatedDate": "2024-09-19T14:05:14.947Z",
        ///       "UpdatedDate": "2024-09-19T14:05:14.947Z"
        ///     }
        ///
        /// </remarks>
        /// <param name="testquestion">Вопрос в тесте</param>
        /// <returns></returns>

        // PUT api/<TestQuestionController>
        [HttpPut]
        public async Task<IActionResult> Update(GetTestQuestionResponse testquestion)
        {
            var Dto = testquestion.Adapt<TestQuestion>();
            await _testquestionService.Update(Dto);
            return Ok();
        }

        /// <summary>
        /// Удаление вопроса в тесте
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<TestQuestionController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _testquestionService.Delete(id);
            return Ok();
        }
    }
}