using Blog.API.DbContexts;
using Blog.API.Models;
using Fusonic.Extensions.EntityFrameworkCore;
using Fusonic.Extensions.MediatR;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Business.UserCommands;

public record GetUserByUserName(string UserName) : IQuery<UserDto>
{
    public class Handler : IRequestHandler<GetUserByUserName, UserDto>
    {
        private readonly PostInfoContext context;

        public Handler(PostInfoContext context) => this.context = context;
        public async Task<UserDto> Handle(GetUserByUserName request, CancellationToken
            cancellationToken)
            {
                var user = await context.Users
                    .Include(u => u.Posts)
                        .ThenInclude(p => p.Comments)
                            .ThenInclude(c => c.Author)
                    .Include(u => u.Comments)
                    .SingleRequiredAsync(x => x.UserName == request.UserName, cancellationToken);
                return new UserDto(user);
            }
    }
}
