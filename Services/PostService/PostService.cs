using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using sanjosefam_backend.Data;
using sanjosefam_backend.Dtos.PostDto;
using sanjosefam_backend.Models;

namespace sanjosefam_backend.Services.PostService
{
  public class PostService : IPostService
  {
    private readonly MainContext _context;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public PostService(MainContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
      _context = context;
      _mapper = mapper;
      _httpContextAccessor = httpContextAccessor;
    }

    private int GetUserId()
    {
      return int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
    }

    public async Task<bool> CreatePost(PostCreateDto request)
    {
      User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());
      if (user == null) return false;
      Post post = new Post { User = user, Content = request.Content };

      await _context.Posts.AddAsync(post);
      await _context.SaveChangesAsync();
      return true;
    }
  }
}
