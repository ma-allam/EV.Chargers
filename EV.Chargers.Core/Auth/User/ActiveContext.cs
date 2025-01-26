

using EV.Chargers.Core.Auth.JWT;

namespace EV.Chargers.Core.Auth.User
{
    public class ActiveContext
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; } = "";
        public string EmailAddress { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string FireBaseToken { get; set; } = "";

        public List<string> Permissions { get; set; } = new List<string>();

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
