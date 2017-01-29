using VirtualTaluva.Server.DataTypes;

namespace VirtualTaluva.Server.Persistance
{
    public interface IDataPersistance
    {
        bool IsUsernameExist(string username);
        bool IsDisplayNameExist(string displayName);
        void Register(UserInfo u);
        UserInfo Get(string username);
        UserInfo Authenticate(string username, string password);
    }
}
