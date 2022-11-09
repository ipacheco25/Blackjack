using Blackjack.Interfaces;
using System;

namespace Blackjack.Events.DeckEventArgs
{
    internal class DeckEventArgs : EventArgs
    {
        public IDeck Deck { get; private set; }
        public DeckEventArgs(IDeck deck) : base()
        {
            Deck = deck;
        }
    }
}
