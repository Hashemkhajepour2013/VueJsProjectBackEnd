using Microsoft.AspNetCore.Mvc;
using ProjectUserPost.Data.Users.Contracts;
using ProjectUserPost.Data.Users.Contracts.Dtos;

namespace ProjectUserPost.MyApi.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public sealed class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<int> Add([FromBody] AddUserDto dto, CancellationToken cancellationToken)
        {
            return await _service.Add(dto, cancellationToken);
        }

        [HttpGet("get-all")]
        public async Task<List<GetAllUserDto>> GetAll()
        {
            return await _service.GetAll();
        }


        [HttpGet("get-all-for-add-post")]
        public async Task<List<GetForAddPost>> GetUsersForAddPost()
        {
            return await _service.GetUsersForAddPost();
        }

        [HttpGet("{id}")]
        public async Task<UserGetByIdDto> GetById(int id, CancellationToken cancellationToken)
        {
            return await _service.GetById(id, cancellationToken);
        }
    }
}
