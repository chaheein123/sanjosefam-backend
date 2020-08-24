using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sanjosefam_backend.Dtos.PostDto;
using sanjosefam_backend.Models;
using sanjosefam_backend.Services.PostService;

namespace sanjosefam_backend.Controllers
{
  [Authorize]
  [Route("posts")]
  [ApiController]
  public class PostController : ControllerBase
  {

    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
      _postService = postService;
    }

    [HttpPost("createpost")]
    public async Task<IActionResult> CreatePost(PostCreateDto request)
    {
      bool isSuccessPost = await _postService.CreatePost(request);
      if (!isSuccessPost) return BadRequest();
      return Ok();
    }

  }
}
