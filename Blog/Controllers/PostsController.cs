using Blog.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers;

[ApiController]
[Route("api/posts")]
public class PostsController : ControllerBase
{
    [HttpGet]
   public ActionResult<IEnumerable<PostDto>> GetPosts()
   {
        return Ok(PostsDataStore.Current.Posts);
   }

[HttpGet("{id}")]
public ActionResult<PostDto> GetPostById(int id)
    {
        var result =
            PostsDataStore.Current.Posts.FirstOrDefault(x => x.Id == id);
        if (result == null)
            return NotFound();

        return Ok(result);
    }
}