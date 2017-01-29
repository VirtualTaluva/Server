using System.Linq;
using VirtualTaluva.Server.DataTypes.Enums;
using VirtualTaluva.Server.DataTypes.EventHandling;
using VirtualTaluva.Server.Logic.Extensions;

namespace VirtualTaluva.Server.Logic.GameModules
{
    public class ShowDownModule : AbstractGameModule
    {
        public ShowDownModule(PokerGameObserver o, PokerTable table)
            : base(o, table)
        {
        }

        public override GameStateEnum GameState => GameStateEnum.Showdown;

        public override void InitModule()
        {
            foreach (var p in Table.Seats.PlayingAndAllInPlayers())
            {
                p.FaceUpCards = p.FaceUpCards.Concat(p.FaceDownCards).ToArray();
                p.FaceDownCards = new string[0];
                Observer.RaisePlayerHoleCardsChanged(p);
            }
            RaiseCompleted();
        }
    }
}
