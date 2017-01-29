using VirtualTaluva.Server.DataTypes.Enums;
using VirtualTaluva.Server.DataTypes.EventHandling;

namespace VirtualTaluva.Server.Logic.GameModules
{
    public class EndGameModule : AbstractGameModule
    {
        public EndGameModule(PokerGameObserver o, PokerTable table)
            : base(o, table)
        {
        }

        public override GameStateEnum GameState => GameStateEnum.End;

        public override void InitModule()
        {
            Observer.RaiseEverythingEnded();
        }
    }
}
