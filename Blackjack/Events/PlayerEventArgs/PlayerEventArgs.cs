using Blackjack.Interfaces;
using System;

namespace Blackjack.Events.PlayerEventArgs
{
    public class PlayerEventArgs : EventArgs
    {
        public IPlayer Player { get; }
        public PlayerEventArgs(IPlayer player)
        {
            Player = player;
        }
    }
}
