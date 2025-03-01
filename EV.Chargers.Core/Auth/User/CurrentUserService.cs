﻿using System.Security.Claims;
using EV.Chargers.Core.Auth.Contract;
using EV.Chargers.Core.Auth.JWT;
using EV.Chargers.Core.Extensions;
using EV.Chargers.Core.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;


namespace EV.Chargers.Core.Auth.User
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly ILogger<CurrentUserService> _logger;
        public ActiveContext activeContext { get; set; }
        readonly IHttpContextAccessor _contextAccessor;

        public CurrentUserService(IHttpContextAccessor contextAccessor, ILogger<CurrentUserService> logger)
        {

            _logger = logger;
            _contextAccessor = contextAccessor;


        }
        public void Load()
        {
            if (activeContext != null) return;
            _logger.LogInformation($"ActiveContext not exists");
            _logger.LogInformation($"User Authenticated status {_contextAccessor?.HttpContext?.User?.Identity?.IsAuthenticated ?? false}");
            if (!(_contextAccessor?.HttpContext?.User?.Identity?.IsAuthenticated ?? false))
            {
                _logger.LogInformation($"Not Authenticated to get ActiveContext");
                throw new UnauthorizedAccessException($"Not Authenticated to get ActiveContext");
            }

            var data = _contextAccessor.HttpContext?.User.GetClaim<string>(JWTClaims.ActiveContext);
            ActiveContext? aContext = JsonConvert.DeserializeObject<ActiveContext>(data.ToString(), new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Converters = new List<JsonConverter> { new TruncateDecimalConverter(0) } // Truncate to 0 decimal places
            });


            activeContext = aContext;
            //activeContext.StudentData.EdStudId = Math.Truncate(activeContext.StudentData.EdStudId);

            //activeContext.IsLoadedFromCache = true;

            //activeContext.Language = _contextAccessor?.HttpContext?.Request.Headers.TryGetValue("Accept-Language", out var httpAcceptLanguage) ?? false ? httpAcceptLanguage.ToString() : "en";
        }
        public bool IsAuthenticated => _contextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;

    }
}
