using Blackjack.Events.GameEventArgs;
using System;

namespace Blackjack.Interfaces
{
    internal interface IGame
    {
        /// <summary>
        /// Fires when the game has ended
        /// </summary>
        event EventHandler<GameEndedEventArgs> GameEnded;
    }
}
