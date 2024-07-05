using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObject;

namespace REST_API.Controllers
{
    public class UserSessionController(IUserSessionService userSessionService) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await userSessionService.GetAllAsync();

            if (response == null) return BadRequest(response);

            if (!response.IsSuccess || response.Value?.Count < 1) return NotFound(response);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await userSessionService.GetAsync(id);

            if (response == null) return BadRequest(response);

            if (!response.IsSuccess) return NotFound(response);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] AddUserSessionModel data)
        {
            var response = await userSessionService.SaveAsync(data);

            if (response == null) return BadRequest(response);

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateUserSessionModel data, int id)
        {
            var response = await userSessionService.UpdateAsync(id, data);

            if (response == null) return BadRequest(response);

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await userSessionService.DeleteAsync(id);

            if (response == null) return BadRequest(response);

            if (!response.IsSuccess) return NotFound(response);

            return Ok(response);
        }
    }
}
