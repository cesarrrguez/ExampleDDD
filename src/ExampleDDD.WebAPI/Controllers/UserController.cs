using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExampleDDD.Application.Interfaces;
using ExampleDDD.Application.ViewModels;

namespace ExampleDDD.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase, IDisposable
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        public async Task<ActionResult<UserViewModel>> Create([FromBody] UserViewModel userViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _userService.RegisterAsync(userViewModel).ConfigureAwait(false);

            return Ok(userViewModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserViewModel>> Update([FromBody] UserViewModel userViewModelInput)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userViewModel = await _userService.GetByIdAsync(userViewModelInput.Id).ConfigureAwait(false);

            if (userViewModel == null) return NotFound();

            await _userService.UpdateAsync(userViewModelInput).ConfigureAwait(false);

            return Ok(userViewModelInput);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserViewModel>> Delete(int id)
        {
            var userViewModel = await _userService.GetByIdAsync(id).ConfigureAwait(false);

            if (userViewModel == null) return NotFound();

            await _userService.RemoveAsync(id).ConfigureAwait(false);

            return Ok(userViewModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> GetById(int id)
        {
            return Ok(await _userService.GetByIdAsync(id).ConfigureAwait(false));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAll()
        {
            return Ok(await _userService.GetAllAsync().ConfigureAwait(false));
        }

        public void Dispose()
        {
            _userService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
