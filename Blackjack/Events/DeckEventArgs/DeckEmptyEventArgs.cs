using Blackjack.Interfaces;
using Blackjack.Models;

namespace Blackjack.Events.DeckEventArgs
{
    internal class DeckEmptyEventArgs : DeckEventArgs
    {
        public bool IsEmpty { get; }
        public DeckEmptyEventArgs(IDeck deck) : base(deck)
        {
            IsEmpty = true;
        }
    }
}
