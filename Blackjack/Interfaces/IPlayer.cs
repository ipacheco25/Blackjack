using Blackjack.Events.PlayerEventArgs;
using System;

namespace Blackjack.Interfaces
{
    internal interface IPlayer
    {
        /// <summary>
        /// Takes a card from the deck
        /// </summary>
        void Hit();

        /// <summary>
        /// Stops taking cards
        /// </summary>
        void Stand();

        /// <summary>
        /// Determines the best hand
        /// </summary>
        void CalculateHand();

        /// <summary>
        /// Fires when player has hit
        /// </summary>
        event EventHandler<PlayerHitEventArgs> Hitted;

        /// <summary>
        /// Fires when player has stood
        /// </summary>
        event EventHandler<PlayerStoodEventArgs> Stood;

        /// <summary>
        /// Fires when player has busted
        /// </summary>
        event EventHandler<PlayerBustedEventArgs> Busted;
    }
}
