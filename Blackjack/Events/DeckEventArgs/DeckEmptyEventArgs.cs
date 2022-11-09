using Blackjack.Models;

namespace Blackjack.Events.DeckEventArgs
{
    internal class DeckEmptyEventArgs : DeckEventArgs
    {
        public bool IsEmpty { get; private set; }
        public DeckEmptyEventArgs(Deck deck) : base(deck)
        {
            IsEmpty = true;
        }
    }
}
