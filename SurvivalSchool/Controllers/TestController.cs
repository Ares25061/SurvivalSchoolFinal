using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SurvivalSchool.Contracts.Test;

namespace SurvivalSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private ITestService _testService;
        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        /// <summary>
        /// Получение информации о всех тестах
        /// </summary>
        /// <returns></returns>

        // GET api/<TestController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _testService.GetAll();
            return Ok(Dto.Adapt<List<GetTestResponse>>());
        }

        /// <summary>
        /// Получение информации о тесте по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<TestController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Dto = await _testService.GetById(id);
            return Ok(Dto.Adapt<GetTestResponse>());
        }

        /// <summary>
        /// Создание нового теста
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "Title" : "string",
        ///        "Description" : "string",
        ///        "CreatedBy": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="test">Тест</param>
        /// <returns></returns>

        // POST api/<TestController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateTestRequest test)
        {
            var Dto = test.Adapt<Test>();
            await _testService.Create(Dto);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о тесте
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "TestId": 1,
        ///       "Title" : "string",
        ///       "Description" : "string",
        ///       "CreatedBy": 1,
        ///       "CreatedDate": "2024-09-19T14:05:14.947Z",
        ///       "UpdatedDate": "2024-09-19T14:05:14.947Z"
        ///     }
        ///
        /// </remarks>
        /// <param name="test">Тест</param>
        /// <returns></returns>

        // PUT api/<TestController>
        [HttpPut]
        public async Task<IActionResult> Update(GetTestResponse test)
        {
            var Dto = test.Adapt<Test>();
            await _testService.Update(Dto);
            return Ok();
        }

        /// <summary>
        /// Удаление теста
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<TestController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _testService.Delete(id);
            return Ok();
        }
    }
}