using Blackjack.Interfaces;
using System;

namespace Blackjack.Events.PlayerEventArgs
{
    internal class PlayerEventArgs : EventArgs
    {
        public IPlayer Player { get; }
        public PlayerEventArgs(IPlayer player)
        {
            Player = player;
        }
    }
}
