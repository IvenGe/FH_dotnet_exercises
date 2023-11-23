using Blog.API.DbContexts;
using Fusonic.Extensions.EntityFrameworkCore;
using Fusonic.Extensions.MediatR;
using MediatR;

namespace Blog.API.Business.Post;

//public record UpdatePostTitle(int PostId, string Title) : ICommand
//{
  //  public class Handler : IRequestHandler<UpdatePostTitle>
//}