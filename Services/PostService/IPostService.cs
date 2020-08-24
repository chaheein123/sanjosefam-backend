using System;
using System.Threading.Tasks;
using sanjosefam_backend.Dtos.PostDto;

namespace sanjosefam_backend.Services.PostService
{
  public interface IPostService
  {
    public Task<bool> CreatePost(PostCreateDto post);

  }
}
