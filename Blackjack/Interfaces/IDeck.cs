using Blackjack.Events.DeckEventArgs;
using Blackjack.Models;
using System;

namespace Blackjack.Interfaces
{
    internal interface IDeck
    {

        /// <summary>
        /// Fires when the deck is empty
        /// </summary>
        event EventHandler<DeckEmptyEventArgs> DeckEmpty;

        /// <summary>
        /// Takes a card from the deck if it is not empty
        /// </summary>
        /// <param name="card">The card taken from the deck</param>
        /// <returns>True, if a card was taken. Otherwise, false.</returns>
        bool TryTakeCard(out Card card);
    }
}
