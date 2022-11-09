using Blackjack.Interfaces;
using System;

namespace Blackjack.Events.GameEventArgs
{
    internal class GameEventArgs : EventArgs
    {
        public IGame Game { get; private set; }
        public GameEventArgs(IGame game)
        {
            Game = game;
        }
    }
}
