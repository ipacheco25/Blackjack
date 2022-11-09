using Blackjack.Events.DeckEventArgs;
using Blackjack.Models;
using System;

namespace Blackjack.Interfaces
{
    internal interface IDeck
    {
        event EventHandler<DeckEmptyEventArgs> DeckEmpty;

        bool TryTakeCard(out Card card);
    }
}
