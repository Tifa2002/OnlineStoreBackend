namespace OnlineStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _UserManager;
        private readonly IConfiguration _Configuration;
        private readonly IMapper _Mapper;
        public AccountController(UserManager<User> userManager, IConfiguration configuration, IMapper mapper)
        {
            _UserManager = userManager;
            _Configuration = configuration;
            _Mapper = mapper;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Regsiter(RegisterUserDTO registerUserDTO)
        {
            User user = new User();
            _Mapper.Map<RegisterUserDTO>(user);

            var Created = await _UserManager.CreateAsync(user, registerUserDTO.Password);
            if (Created.Succeeded)
            {
                return Ok(registerUserDTO);
            }
            return BadRequest(registerUserDTO);
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserDTO loginUserDTO)
        {
            if (ModelState.IsValid)
            {
                var ValidUser = await _UserManager.FindByNameAsync(loginUserDTO.UserName);
                if (ValidUser is not null)
                {
                    bool checkPassword = await _UserManager.CheckPasswordAsync(ValidUser, loginUserDTO.Password);
                    if (checkPassword)
                    {
                        //TODO Add the CartId And WishLIst ID 
                        List<Claim> Userclaims = new List<Claim>();
                        Userclaims.Add(new Claim(ClaimTypes.Name, ValidUser.UserName!));
                        Userclaims.Add(new Claim(ClaimTypes.NameIdentifier, ValidUser.Id));
                        Userclaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                        var roles = await _UserManager.GetRolesAsync(ValidUser);
                        foreach (var role in roles)
                        {
                            Userclaims.Add(new Claim(ClaimTypes.Role, role));
                        }


                        SymmetricSecurityKey key =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["Jwt:key"]!));

                        SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


                        JwtSecurityToken JwtToken = new JwtSecurityToken
                        (
                           issuer: _Configuration["Jwt:Issu"],
                           audience: _Configuration["Jwt:Aud"],
                           expires: DateTime.Now.AddDays(1),
                           claims: Userclaims,
                           signingCredentials: credentials

                        );
                        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                        var SuccessToken = new GeneratedToken(handler.WriteToken(JwtToken), JwtToken.ValidTo);
                        return Ok(new GeneralResponse<GeneratedToken>(true, "Login Successfully", SuccessToken));
                    }
                }
            }
            return Unauthorized(new GeneralResponse<string>(false,"User Not Found",loginUserDTO.UserName));
        }

        
    }
}
