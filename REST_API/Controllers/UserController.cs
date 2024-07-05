using Domain.Interfaces.Services;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.DataTransferObject;

namespace REST_API.Controllers
{
    public class UserController(IUserService userService) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await userService.GetAllAsync();

            if (response == null) return BadRequest(response);

            if (!response.IsSuccess || response.Value?.Count < 1) return NotFound(response);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await userService.GetAsync(id);

            if (response == null) return BadRequest(response);

            if (!response.IsSuccess) return NotFound(response);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] AddUserModel data)
        {
            var response = await userService.SaveAsync(data);

            if (response == null) return BadRequest(response);

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateUserModel data, int id)
        {
            var response = await userService.UpdateAsync(id, data);

            if (response == null) return BadRequest(response);

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await userService.DeleteAsync(id);

            if (response == null) return BadRequest(response);

            if (!response.IsSuccess) return NotFound(response);

            return Ok(response);
        }
    }
}
