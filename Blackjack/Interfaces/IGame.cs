using Blackjack.Enums;
using Blackjack.Events.GameEventArgs;
using Blackjack.Models;
using System;

namespace Blackjack.Interfaces
{
    public interface IGame
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
        /// Results of the game
        /// </summary>
        EResults Results { get; }

        /// <summary>
        /// Fires when the game has ended
        /// </summary>
        event EventHandler<GameEndedEventArgs> GameEnded;
    }
}
