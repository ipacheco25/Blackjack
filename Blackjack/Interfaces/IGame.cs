using Blackjack.Events.GameEventArgs;
using Blackjack.Models;
using Blackjack.ViewModels;
using System;

namespace Blackjack.Interfaces
{
    internal interface IGame
    {
        /// <summary>
        /// The Dealer
        /// </summary>
        PlayerViewModel Dealer { get; }

        /// <summary>
        /// The Player
        /// </summary>
        PlayerViewModel Player { get; }

        /// <summary>
        /// Fires when the game has ended
        /// </summary>
        event EventHandler<GameEndedEventArgs> GameEnded;
    }
}
