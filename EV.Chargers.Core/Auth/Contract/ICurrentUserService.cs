using EV.Chargers.Core.Auth.User;

namespace EV.Chargers.Core.Auth.Contract
{
    public interface ICurrentUserService
    {
        void Load();
        ActiveContext activeContext { get; set; }



    }
}
