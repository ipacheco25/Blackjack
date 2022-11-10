using Blackjack.Events.PlayerEventArgs;
using Blackjack.Models;
using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Blackjack.Interfaces
{
    internal interface IPlayer
    {
        /// <summary>
        /// The cards in the players hand
        /// </summary>
        List<Card> Hand { get; }

        /// <summary>
        /// The total value of the players hand
        /// </summary>
        int Value { get; }

        /// <summary>
        /// The player has stood
        /// </summary>
        bool HasStood { get; }

        /// <summary>
        /// Fires after the player hit
        /// </summary>
        event EventHandler<PlayerHitEventArgs> PlayerHit;

        /// <summary>
        /// Fires after the player stands
        /// </summary>
        event EventHandler<PlayerStoodEventArgs> PlayerStood;

        /// <summary>
        /// Fires after the player busts
        /// </summary>
        event EventHandler<PlayerBustedEventArgs> PlayerBusted;

        /// <summary>
        /// Takes a card from the deck
        /// </summary>
        void Hit();

        /// <summary>
        /// Stops taking cards
        /// </summary>
        void Stand();
    }
}
