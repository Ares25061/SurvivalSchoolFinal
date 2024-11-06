using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SurvivalSchool.Contracts.UserTestResult;

namespace SurvivalSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTestResultController : ControllerBase
    {
        private IUserTestResultService _usertestresultService;
        public UserTestResultController(IUserTestResultService usertestresultService)
        {
            _usertestresultService = usertestresultService;
        }

        /// <summary>
        /// Получение информации о всех результатах тестов пользователей
        /// </summary>
        /// <returns></returns>

        // GET api/<UserTestResultController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _usertestresultService.GetAll();
            return Ok(Dto.Adapt<List<GetUserTestResultResponse>>());
        }

        /// <summary>
        /// Получение информации о результате теста пользователя по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<UserTestResultController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Dto = await _usertestresultService.GetById(id);
            return Ok(Dto.Adapt<GetUserTestResultResponse>());
        }

        /// <summary>
        /// Создание нового результата теста пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "UserId": 1,
        ///        "TestId": 1,
        ///        "Score" : 5
        ///     }
        ///
        /// </remarks>
        /// <param name="usertestresult">Результат теста пользователя</param>
        /// <returns></returns>

        // POST api/<UserTestResultController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserTestResultRequest usertestresult)
        {
            var Dto = usertestresult.Adapt<UserTestResult>();
            await _usertestresultService.Create(Dto);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о результате теста пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "ResultId": 1,
        ///       "UserId": 1,
        ///       "TestId": 1,
        ///       "Score" : 5,
        ///       "CompletedDate": "2024-09-19T14:05:14.947Z"
        ///     }
        ///
        /// </remarks>
        /// <param name="usertestresult">Результат теста пользователя</param>
        /// <returns></returns>

        // PUT api/<UserTestResultController>
        [HttpPut]
        public async Task<IActionResult> Update(GetUserTestResultResponse usertestresult)
        {
            var Dto = usertestresult.Adapt<UserTestResult>();
            await _usertestresultService.Update(Dto);
            return Ok();
        }

        /// <summary>
        /// Удаление результата теста пользователя
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<UserTestResultController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _usertestresultService.Delete(id);
            return Ok();
        }
    }
}