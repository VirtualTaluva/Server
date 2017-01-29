﻿using System.Linq;
using VirtualTaluva.Protocol.DataTypes;
using VirtualTaluva.Protocol.DataTypes.Enums;
using VirtualTaluva.Server.DataTypes.EventHandling;
using VirtualTaluva.Server.Logic.Extensions;

namespace VirtualTaluva.Server.Logic.GameModules
{
    public class FirstBettingRoundModule : BettingRoundModule
    {
        public FirstBettingRoundModule(PokerGameObserver o, PokerTable table)
            : base(o, table)
        {
        }

        protected override SeatInfo GetSeatOfTheFirstPlayer()
        {
            if (Table.Params.Blind == BlindTypeEnum.Blinds)
            {
                //Ad B : A      A
                //Ad B C: A     A->B->C->A
                //Ad B C D: D   A->B->C->D
                return Table.Seats.PlayingAndAllInPlayers().Count() < 3 ? Table.Seats.SeatOfDealer() : Table.Seats.SeatOfPlayingPlayerNextTo(Table.Seats.SeatOfPlayingPlayerNextTo(Table.Seats.SeatOfPlayingPlayerNextTo(Table.Seats.SeatOfDealer())));
            }

            return base.GetSeatOfTheFirstPlayer();
        }
    }
}
