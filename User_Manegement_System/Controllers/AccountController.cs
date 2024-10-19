using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using User_Manegement_System.Data;
using User_Manegement_System.Model;

namespace User_Manegement_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region Constractor

        private readonly MyContext _context;

        public AccountController(MyContext context)
        {
            _context = context;
        }

        #endregion


        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDTO login)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == login.Username && u.Password == login.Password);
            if (user == null) return Unauthorized();

            var token = GenerateJwtToken(user); // Get Token with user information
            return Ok(new { Token = token });
        }

        // Create Token And Encryption
        private string GenerateJwtToken(tbl_user user)
        {
            var claims = new[]
            {
              new Claim(ClaimTypes.Name, user.Username),
              new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Xy2@#S8wL!29uD&f^$%Qo9*VWsM1Pb^R")); // Secret Private Key
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "JwtAuthApi",
                audience: "InternalServices",
                claims: claims, // Claims Info (User Info)
                expires: DateTime.Now.AddHours(1), // Terminate Time
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
