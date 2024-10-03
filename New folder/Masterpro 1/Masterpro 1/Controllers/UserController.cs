using Masterpro_1.DTOs;
using Masterpro_1.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly MyDbContext _db;

    public UsersController(MyDbContext db)
    {
        _db = db;
    }

    // Registration Route
    [HttpPost("register")]
    public IActionResult Register([FromForm] UserRequestDTO model)
    {
        // Validate if Password and ConfirmPassword match
        if (model.Password != model.ConfirmPassword)
        {
            return BadRequest("Password and Confirm Password do not match.");
        }

        // Check if the user already exists by email
        var existingUser = _db.Users.FirstOrDefault(u => u.Email == model.Email);
        if (existingUser != null)
        {
            return Conflict("Email already exists.");
        }

        // Create a new User entity and populate it with data from the DTO
        User newUser = new User
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            Password = model.Password,  // Store the plain password (not secure)
            Phone = model.Phone,
            Role = model.Role
        };

        // Add the user to the database
        _db.Users.Add(newUser);
        _db.SaveChanges();

        return Ok(new { message = "User registered successfully!" });
    }
    [HttpPost("login")]
    public IActionResult Login([FromBody] UserRequestDTO model)
    {

        // Validate the input
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Check if the user exists in the database
        var user = _db.Users.FirstOrDefault(u => u.Email == model.Email);

        // Validate the password
        if (user == null || user.Password != model.Password)
        {
            return Unauthorized(new { message = "Invalid email or password." });
        }

        // Return success message on valid login
        return Ok(new { message = "Login successful", email = model.Email });
    }

}
