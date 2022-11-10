using Blackjack.Events.GameEventArgs;
using Blackjack.Models;
using System;

namespace Blackjack.Interfaces
{
    internal interface IGame
    {
        /// <summary>
        /// The Dealer
        /// </summary>
        Dealer Dealer { get; }

        /// <summary>
        /// The Player
        /// </summary>
        Player Player { get; }

        /// <summary>
        /// Fires when the game has ended
        /// </summary>
        event EventHandler<GameEndedEventArgs> GameEnded;
    }
}
