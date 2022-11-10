using Blackjack.Interfaces;
using System;

namespace Blackjack.Events.GameEventArgs
{
    internal class GameEventArgs : EventArgs
    {
        public IGame Game { get; }
        public GameEventArgs(IGame game)
        {
            Game = game;
        }
    }
}
