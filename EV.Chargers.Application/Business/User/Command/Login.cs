﻿using System.IdentityModel.Tokens.Jwt;
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
using Newtonsoft.Json;
using EV.Chargers.Core.Auth.JWT;
using EV.Chargers.Core.Auth.User;
using EV.Chargers.Core.Exceptions;
using EV.Chargers.Domain.Entities;

namespace EV.Chargers.Application.Business.User.Command
{
    public class LoginHandler : IRequestHandler<LoginHandlerInput, LoginHandlerOutput>
    {
        private readonly IDataBaseService _databaseService;
        private readonly ILogger<LoginHandler> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtHandler _jwtHandler;


        public LoginHandler(ILogger<LoginHandler> logger, IDataBaseService databaseService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IJwtHandler jwtHandler)
        {
            _logger = logger;
            _databaseService = databaseService;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _jwtHandler = jwtHandler;
        }

        public async Task<LoginHandlerOutput> Handle(LoginHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling Login business logic");
            LoginHandlerOutput output = new LoginHandlerOutput(request.CorrelationId());

            var user = await _userManager.FindByNameAsync(request.Username);
            var roles = await _userManager.GetRolesAsync(user);
            if (user == null) throw new WebApiException($"Account with {request.Username} User Name Not Found, Please contact system administrator");

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, isPersistent: false, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                var userData = await _databaseService.UserData.Where(o => o.UserId == user.Id).FirstOrDefaultAsync();
                userData.FirebaseToken=request.FireBaseToken;
                _databaseService.UserData.Update(userData);
                await _databaseService.DBSaveChangesAsync();
                ActiveContext activeContext = new ActiveContext { UserId = userData.Id, UserName = userData.FirebaseId,  EmailAddress = user.Email,PhoneNumber=userData.Phone, FullName = userData.UserName,FireBaseToken=request.FireBaseToken };
                activeContext.Permissions.AddRange( roles);
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
            else if (result.IsLockedOut)
            {
                throw new WebApiException("Account locked out due to multiple failed login attempts. Please try again later.");
            }
            else
            {
                throw new WebApiException("Please Check Password");
            }

            return output;
        }

        public async Task<string> GenerateJwtToken(ApplicationUser user)
        {
            var userDataId = await _databaseService.UserData.Where(o => o.UserId == user.Id).Select(o => o.Id).FirstOrDefaultAsync();
            ActiveContext activeContext = new ActiveContext { UserName = user.UserName, UserId = userDataId };
            var data = JsonConvert.SerializeObject(activeContext, Formatting.None,
                             new JsonSerializerSettings()
                             {
                                 ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                             });

            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();

            var claims = new List<Claim>
                                        {
                                            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                            new Claim(JWTClaims.ActiveContext, data)
                                        }.Union(roleClaims);

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
