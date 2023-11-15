using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly BloggingContext _context;
    // Inject any other services you need, like a token service for JWT

    public AccountController(BloggingContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(UserDto userDto)
    {
        // Create user, hash password, etc.
        // Save the user in the database
        // Return some result
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>> Login(LoginDto loginDto)
    {
        // Authenticate user
        // Generate JWT token if valid
        // Return the token
    }
}