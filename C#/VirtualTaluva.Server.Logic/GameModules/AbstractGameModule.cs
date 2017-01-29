using System;
using System.Threading;
using VirtualTaluva.Protocol.DataTypes;
using VirtualTaluva.Server.DataTypes;
using VirtualTaluva.Server.DataTypes.Enums;
using VirtualTaluva.Server.DataTypes.EventHandling;

namespace VirtualTaluva.Server.Logic.GameModules
{
    public abstract class AbstractGameModule : IGameModule
    {
        public event EventHandler<SuccessEventArg> ModuleCompleted = delegate { };
        public event EventHandler<ModuleEventArg> ModuleGenerated = delegate { };

        public abstract GameStateEnum GameState { get; }

        protected PokerGameObserver Observer { get; private set; }
        protected PokerTable Table { get; private set; }

        protected AbstractGameModule(PokerGameObserver o, PokerTable table)
        {
            Observer = o;
            Table = table;
        }

        public virtual void InitModule()
        {

        }

        protected virtual void EndModule()
        {

        }
        public virtual void OnSitIn()
        {

        }
        public virtual void OnSitOut()
        {

        }

        public virtual bool OnMoneyPlayed(PlayerInfo p, int amount)
        {
            return false;
        }

        public virtual void OnCardDiscarded(PlayerInfo p, string[] cards)
        {
        }

        protected void RaiseCompleted()
        {
            EndModule();
            ModuleCompleted(this, new SuccessEventArg() { Success = true });
        }
        protected void RaiseAborted()
        {
            ModuleCompleted(this, new SuccessEventArg() { Success = false });
        }

        protected void AddModule(IGameModule module)
        {
            ModuleGenerated(this, new ModuleEventArg() {Module = module});
        }
        protected void WaitALittle(int waitingTime)
        {
            Thread.Sleep(waitingTime);
        }
    }
}
