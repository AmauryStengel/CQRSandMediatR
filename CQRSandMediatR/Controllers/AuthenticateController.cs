using CQRSandMediatR.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CQRSandMediatR.Controllers
{
    [Route("api/auth")]
    [ApiController]
    
    public class AuthenticateController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthenticateController(IConfiguration configuration,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserModel userModel)
        {
            var userExists = await _userManager.FindByEmailAsync(userModel.UserName);
            if (userExists is not null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseModel
                {
                    Success = false,
                    Message = "User already exists!"
                });
            }
            IdentityUser user = new()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = userModel.UserName,
                Email = userModel.Email,
            };
            var result = await _userManager.CreateAsync(user, userModel.Password);
            if (!result.Succeeded)
            {
                var msg = result.Errors.Count() > 0 ? result.Errors.FirstOrDefault().Description : "Error while creating user.";
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseModel
                {
                    Success = false,
                    Message = msg
                });
            }

            var role = userModel.IsAdmin ? UserRules.Admin : UserRules.User;
            await AddToRoleAsync(user, role);
            return Ok(new ResponseModel
            {
                Message = "User created successfully!"
            });
        }

        [HttpPost]
        [Route("login")] //nome de Route é sempre minúsculo
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel loginModel)
        {
            var user = await _userManager.FindByNameAsync(loginModel.UserName);
            if (user is not null && await _userManager.CheckPasswordAsync(user, loginModel.Password)) { 
                var authClaims = new List<Claim> // Claim - lista de permissões
                {
                    new(ClaimTypes.Name, user.UserName),
                    new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) //Guid = Generate Unique ID
                };

                var userRoles = await _userManager.GetRolesAsync(user);
                foreach (var userRole in  userRoles)
                {
                    authClaims.Add(new(ClaimTypes.Role, userRole));
                }

                return Ok(new ResponseModel
                {
                    Data = GetToken(authClaims)
                });
            }

            return Unauthorized();
        }

        private TokenModel GetToken(List<Claim> authClaims)
        {
            var authSignInKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSignInKey, SecurityAlgorithms.HmacSha256)
                );
            return new()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ValidTo = token.ValidTo
            };
        }

        private async Task AddToRoleAsync(IdentityUser user, string role)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                await _roleManager.CreateAsync(new(role));
            }
            await _userManager.AddToRoleAsync(user, role);
        }
    }
}
