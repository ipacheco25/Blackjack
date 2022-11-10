using Blackjack.Interfaces;
using System;

namespace Blackjack.Events.DeckEventArgs
{
    internal class DeckEventArgs : EventArgs
    {
        public IDeck Deck { get; }
        public DeckEventArgs(IDeck deck) : base()
        {
            Deck = deck;
        }
    }
}
