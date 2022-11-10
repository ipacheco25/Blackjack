﻿using Blackjack.Interfaces;

namespace Blackjack.Events.PlayerEventArgs
{
    internal class PlayerHitEventArgs : PlayerEventArgs
    {
        public bool Hit { get; private set; }
        public PlayerHitEventArgs(IPlayer player, bool hit) : base(player)
        {
            Hit = hit;
        }
    }
}