using Blackjack.Interfaces;
using System;

namespace Blackjack.Events.GameEventArgs
{
    public class GameEventArgs : EventArgs
    {
        public IGame Game { get; }
        public GameEventArgs(IGame game)
        {
            Game = game;
        }
    }
}
