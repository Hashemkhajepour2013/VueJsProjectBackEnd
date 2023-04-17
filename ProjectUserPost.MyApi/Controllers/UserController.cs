using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProjectUserPost.Data.Users.Contracts;
using ProjectUserPost.Data.Users.Contracts.Dtos;

namespace ProjectUserPost.MyApi.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [EnableCors("CorsPolicy")]
    public sealed class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("add-user")]
        public Task<int> Add([FromBody] AddUserDto dto, CancellationToken cancellationToken)
        {
            return _service.Add(dto, cancellationToken);
        }

        [HttpPut("{id}")]
        public async Task Edit(int id, [FromBody] EditUserDto dto, CancellationToken cancellationToken)
        {
            await _service.Edit(id, dto, cancellationToken);
        }
        
        [HttpGet("get-all")]
        public async Task<List<GetAllUserDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _service.GetAll(cancellationToken);
        }


        [HttpGet("get-all-for-add-post")]
        public async Task<List<GetForAddPost>> GetUsersForAddPost(CancellationToken cancellationToken)
        {
            return await _service.GetUsersForAddPost(cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<UserGetByIdDto> GetById(int id, CancellationToken cancellationToken)
        {
            return await _service.GetById(id, cancellationToken);
        }

        [HttpPut("change-state/{id}")]
        public async Task<bool> ChangeState(int id, CancellationToken cancellationToken)
        {
            await _service.ChangeActive(id, cancellationToken);
            return true;
        }

        [HttpDelete("delete/{id}")]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
           await _service.Delete(id, cancellationToken);
        }
    }
}
