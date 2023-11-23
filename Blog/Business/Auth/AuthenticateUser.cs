using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;
using System.Text;
using Blog.API.Entities;
using Fusonic.Extensions.MediatR;
using MediatR;
using MediatR.Wrappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Blog.API.Business.Auth;

public record AuthenticateUser(string Username, string Password) :
ICommand<AuthenticateUser.Result>
{
    public record Result(bool Successful, string? Token);

    public class Handler : IRequestHandler<AuthenticateUser, Result>
    {
    private readonly UserManager<User> userManager;
    private readonly IConfiguration configuration;

    public Handler(UserManager<User> userManager, IConfiguration configuration)
    {
        this.userManager = userManager;
        this.configuration = configuration;
    }

    public async Task<Result> Handle(AuthenticateUser request,
                                     CancellationToken cancellationToken)
    {
        var user = await userManager.FindByNameAsync(request.Username);
        var authSuccessfull = user != null
            && await userManager.CheckPasswordAsync(user, request.Password);

        string? token = null;

        if (authSuccessfull)
        {
            var credentials = GetSigningCredentials();
            var claims = await GetClaims(user);
            var tokenOptions = GenerateTokenOptions(credentials, claims);
            token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        return new Result(authSuccessfull, token);
    }

    private SigningCredentials GetSigningCredentials()
    {
        var jwtConfig = configuration.GetSection("jwtConfig");
        var key = Encoding.UTF8.GetBytes(jwtConfig["Secret"]);
        var secret = new SymmetricSecurityKey(key);
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    private async Task<List<Claim>> GetClaims(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.GivenName, user.FirstName ?? ""),
            new Claim(ClaimTypes.Surname, user.LastName ?? ""),
            new Claim(ClaimTypes.NameIdentifier, user.Id ?? "")
        };

        var roles = await userManager.GetRolesAsync(user);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        return claims;
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials
    credentials, List<Claim> claims)
    {
        var jwtSettings = configuration.GetSection("JwtConfig");
        return new JwtSecurityToken
        (
            issuer: jwtSettings["validIssuer"],
            audience: jwtSettings["validAudience"],
            claims: claims,
            expires:
            DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expiresIn"])),
            signingCredentials: credentials
        );
    }
}
}
