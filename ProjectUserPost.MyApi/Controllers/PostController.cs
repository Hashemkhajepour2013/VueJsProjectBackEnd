﻿using Microsoft.AspNetCore.Mvc;
using ProjectUserPost.Data.Posts.Cotracts;
using ProjectUserPost.Data.Posts.Cotracts.Dtos;

namespace ProjectUserPost.MyApi.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public sealed class PostController : ControllerBase
    {
        private readonly IPostService _service;
        public PostController(IPostService service)
        {
            _service = service;
        }

        [HttpPost]
        public Task<int> Add([FromBody] AddPostDto dto, CancellationToken cancellationToken)
        {
            return _service.Add(dto, cancellationToken);
        }

        [HttpGet("get-all")]
        public async Task<List<GetAllPostDto>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public Task<PostGetById> GetById(int id, CancellationToken cancellationToken)
        {
            return _service.GetById(id, cancellationToken);
        }

        [HttpPut("edit/{id}")]
        public Task <int> Edit(int id, EditPostDto dto, CancellationToken cancellationToken)
        {
            return _service.Edit(id, dto, cancellationToken);
        }
    }
}
