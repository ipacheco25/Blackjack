﻿using Blackjack.Enums;
using Blackjack.Interfaces;
using Blackjack.Models;

namespace Blackjack.Events.GameEventArgs
{
    public class GameEndedEventArgs : GameEventArgs
    {
        public EGameResults Results { get; }
        public GameEndedEventArgs(IGame game, EGameResults results) : base(game)
        {
            Results = results;
        }
    }
}
