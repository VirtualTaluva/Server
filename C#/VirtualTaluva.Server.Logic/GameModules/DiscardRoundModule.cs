﻿using System.Collections.Generic;
using System.Linq;
using VirtualTaluva.Protocol.DataTypes;
using VirtualTaluva.Server.DataTypes.Enums;
using VirtualTaluva.Server.DataTypes.EventHandling;
using VirtualTaluva.Server.Logic.Extensions;

namespace VirtualTaluva.Server.Logic.GameModules
{
    public class DiscardRoundModule : AbstractGameModule
    {
        private readonly int m_Minimum;
        private readonly int m_Maximum;
        private readonly Dictionary<PlayerInfo, string[]> m_Players = new Dictionary<PlayerInfo, string[]>();  
        public DiscardRoundModule(PokerGameObserver o, PokerTable table, int minimum, int maximum)
            : base(o, table)
        {
            m_Minimum = minimum;
            m_Maximum = maximum;
        }

        public override GameStateEnum GameState => GameStateEnum.Playing;

        public override void InitModule()
        {
            foreach(var p in Table.Seats.PlayingPlayers())
                m_Players.Add(p,null);
            Observer.RaiseDiscardActionNeeded(m_Minimum, m_Maximum);
        }

        protected override void EndModule()
        {
            foreach (var p in m_Players.Keys)
            {
                p.FaceDownCards = p.FaceDownCards.Select(x => x.ToUpper()).Except(m_Players[p].Select(x => x.ToUpper())).ToArray();
                Observer.RaisePlayerHoleCardsChanged(p);
            }
            WaitALittle(Table.Params.WaitingTimes.AfterPotWon);
            base.EndModule();
        }

        public override void OnCardDiscarded(PlayerInfo p, string[] cards)
        {
            if (!m_Players.ContainsKey(p) || m_Players[p] != null || cards.Length < m_Minimum || cards.Length > m_Maximum)
                return;
            m_Players[p] = cards;
            if (m_Players.All(x => x.Value != null))
                RaiseCompleted();
        }
    }
}
