using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EV.Chargers.Application.Contract;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using EV.Chargers.Core.Auth.JWT;
using EV.Chargers.Core.Auth.User;
using EV.Chargers.Domain.Entities;

namespace EV.Chargers.Application.Business.User.Command
{
    public class RegisterHandler : IRequestHandler<RegisterHandlerInput, RegisterHandlerOutput>
    {
        private readonly IDataBaseService _databaseService;
        private readonly ILogger<LoginHandler> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IJwtHandler _jwtHandler;


        public RegisterHandler(ILogger<LoginHandler> logger, IDataBaseService databaseService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IJwtHandler jwtHandler)
        {
            _logger = logger;
            _databaseService = databaseService;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _jwtHandler = jwtHandler;
            _httpContextAccessor = httpContextAccessor;


        }

        public async Task<RegisterHandlerOutput> Handle(RegisterHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling Register business logic");
            RegisterHandlerOutput output = new RegisterHandlerOutput(request.CorrelationId());

            using (var transaction = await _databaseService.BeginTransactionAsync(cancellationToken))
            {
                try
                {
                    var user = new ApplicationUser
                    {
                        UserName = request.Username,
                        Email = request.Email,
                        PhoneNumber = request.PhoneNumber,
                    };

                    var result = await _userManager.CreateAsync(user, request.Password);

                    if (!result.Succeeded)
                    {
                        throw new Exception("User creation failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
                    }

                    var userData = new UserData
                    {
                        FirebaseId = user.UserName,
                        UserName = request.FullName,
                        Email = user.Email,
                        Phone = user.PhoneNumber,
                        UserId = user.Id,
                        FirebaseToken = request.FireBaseToken
                    };

                    _databaseService.UserData.Add(userData);
                    await _databaseService.DBSaveChangesAsync(cancellationToken);

                    await transaction.CommitAsync(cancellationToken);

                    // Optionally, sign in the user after registration
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    ActiveContext activeContext = new ActiveContext { UserId = userData.Id, UserName = userData.FirebaseId, EmailAddress = user.Email, PhoneNumber = userData.Phone, FullName = userData.UserName, FireBaseToken = request.FireBaseToken };
                    var token = _jwtHandler.CreateWithRefreshToken(activeContext);

                    //var token = await GenerateJwtToken(user);
                    output.Context = token;

                    // Save login history
                    var loginTime = DateTime.UtcNow.ToString("o");
                    var ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress?.ToString();

                    var loginToken = new IdentityUserToken<string>
                    {
                        UserId = user.Id,
                        LoginProvider = "LoginTracker",
                        Name = "LoginEvent",
                        Value = $"{loginTime};{ipAddress}"
                    };

                    await _userManager.SetAuthenticationTokenAsync(user, loginToken.LoginProvider, loginToken.Name, loginToken.Value);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    _logger.LogError(ex, "Error occurred during user registration");
                    throw;
                }
            }

            return output;
        }

        public string GenerateJwtToken(ApplicationUser user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpiryMinutes"])),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
