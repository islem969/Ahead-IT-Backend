
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Register.Context;
using Register.Helpers;
using Register.Models;
using Register.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Register.Models.DTO;

namespace Register.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _authContext;

        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(AppDbContext appDbContext, IUserService userService, IMapper mapper)
        {
            _authContext = appDbContext;
            _userService = userService;
            _mapper = mapper; 
        }
     


        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserLoginModel userLogin)
        {
            if (userLogin == null)
                return BadRequest();

            var user = await _authContext.Users.FirstOrDefaultAsync(x => x.Username == userLogin.Username);

            if (user == null)
                return NotFound(new { Message = "User Not Found!" });

            if (!PasswordHasher.VerifyPassword(userLogin.Password, user.Password))
            {
                Console.WriteLine(userLogin.Password);
                Console.WriteLine(user.Password);
                Console.WriteLine(PasswordHasher.VerifyPassword(userLogin.Password, user.Password));
                return BadRequest(new { Message = "Password is Incorrect" });
            }

            string Token = CreateJwt(user);
            await _authContext.SaveChangesAsync();


            return Ok(new

            {
                user.Role,
                user.FirstName,
                user.Email,
                user.Cin,
                user.Id,
                Token = Token,
                Message = "Login Success!"

            });
        }


        [HttpPost("register")]

        public async Task<IActionResult> RegisterUser([FromBody] User userObj)
        {
            if (userObj == null)
                return BadRequest();

            //Check userName
            if (await CheckUserNameExistAsync(userObj.Username))
                return BadRequest(new { Message = "Username Already Exist!" });
            // Check Email
            if (await CheckEmailExistAsync(userObj.Email))
                return BadRequest(new { Message = "Email Already Exist!" });
            //Check Password
            var pass = CheckPasswordStrenght(userObj.Password);
            if (!string.IsNullOrEmpty(pass))
                return BadRequest(new { Message = pass.ToString() });

            userObj.Password = PasswordHasher.HashPassword(userObj.Password);
            userObj.Role = "User";
            userObj.Token = "";
            await _authContext.Users.AddAsync(userObj);
            await _authContext.SaveChangesAsync();

            return Ok(new { Message = "User Registered!" });
        }
        private Task<bool> CheckUserNameExistAsync(string userName)
        => _authContext.Users.AnyAsync(x => x.Username == userName);
        private Task<bool> CheckEmailExistAsync(string email)
        => _authContext.Users.AnyAsync(x => x.Email == email);

        private string CheckPasswordStrenght(string password)
        {
            StringBuilder sb = new StringBuilder();
            if (password.Length < 8)
                sb.Append("Minimum password lenght should be 8" + Environment.NewLine);
            if (!(Regex.IsMatch(password, "[a-z]") && Regex.IsMatch(password, "[A-Z]")
                && Regex.IsMatch(password, "[0-9]")))
                sb.Append("Password should be alphanumeric" + Environment.NewLine);
            if (!(Regex.IsMatch(password, "[<,>,@,!,#,/,{,},+,-,*,=]")))
                sb.Append("Password should contain special chars" + Environment.NewLine);
            return sb.ToString();

        }
        //Creation token
        private string CreateJwt(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("1234567890abcdef1234567890abcdef");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Name,$"{user.Username}")
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDto userUpdateDto)
        {
            if (userUpdateDto == null)
            {
                return BadRequest("User update data is null.");
            }

            try
            {
                var result = await _userService.UpdateUserAsync(id, userUpdateDto);
                if (!result)
                {
                    return NotFound("User not found.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception (using a logging framework such as Serilog, NLog, etc.)
                // Log.Error(ex, "An error occurred while updating the user");

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserUpdateDto>> GetUser(int id)
        {
            // Recherche de l'utilisateur dans la base de données par son ID
            var user = await _userService.GetUserById(id);

            // Vérification si l'utilisateur existe
            if (user == null)
            {
                // Retourne une réponse 404 Not Found si l'utilisateur n'est pas trouvé
                return NotFound();
            }

            // Mapper l'entité User vers UserUpdateDto à l'aide d'AutoMapper
            var userDto = _mapper.Map<UserUpdateDto>(user);

            // Retourne une réponse HTTP 200 OK avec les données de l'utilisateur au format UserUpdateDto
            return Ok(userDto);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<User>> GetAllUsers()
        {
            return Ok(await _authContext.Users.ToListAsync());

        }
        [HttpGet("/profil/{id}")]
        public async Task<ActionResult<ProfileDto>> GetUserProfil(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();

            return Ok(user);
        }


    }

    }
       
    
