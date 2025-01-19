﻿

using EV.Chargers.Core.Auth.JWT;

namespace EV.Chargers.Core.Auth.User
{
    public class ActiveContext
    {
        public string UserName { get; set; }
        public string FullName { get; set; } = "";
        public string EmailAddress { get; set; } = "";
        public List<string> Permissions { get; set; } = new List<string>();

        public long UserId { get; set; }
        public string Language { get; set; } = "en";
        public Guid ActiveContextId { get; set; } = Guid.Empty;
        public JsonWebToken Token { get; set; } = new JsonWebToken();
        public bool IsEnglish()
        {
            return Language.Contains("en");
        }
        public static ActiveContext Build() => new ActiveContext();

    }
}
