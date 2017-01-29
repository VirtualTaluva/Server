using System;
using VirtualTaluva.Protocol.DataTypes;
using VirtualTaluva.Server.DataTypes.Enums;
using VirtualTaluva.Server.DataTypes.EventHandling;

namespace VirtualTaluva.Server.DataTypes
{
    public interface IGameModule
    {
        event EventHandler<SuccessEventArg> ModuleCompleted;
        event EventHandler<ModuleEventArg> ModuleGenerated;
        GameStateEnum GameState { get; }

        void InitModule();
        void OnSitOut();
        void OnSitIn();
        bool OnMoneyPlayed(PlayerInfo p, int amount);
        void OnCardDiscarded(PlayerInfo p, string[] cards);
    }
}
