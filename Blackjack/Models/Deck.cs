using Blackjack.Enums;
using Blackjack.Events.DeckEventArgs;
using Blackjack.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack.Models
{
    internal class Deck : IDeck
    {

        private static Deck _instance;

        /// <summary>
        /// Singleton instance of the deck
        /// </summary>
        public static Deck Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Deck();
                }

                return _instance;
            }
        }

        /// <summary>
        /// The cards in the deck
        /// </summary>
        private Stack<Card> Cards { get; set; }

        private Deck()
        {
            List<Card> cards = new List<Card>();
            var suits = Enum.GetValues(typeof(ESuits)).Cast<ESuits>();
            foreach (var suit in suits)
            {
                var ranks = Enum.GetValues(typeof(ERanks)).Cast<ERanks>();
                foreach (var rank in ranks)
                {
                    Card card = new Card(rank, suit);
                    cards.Add(card);
                }
            }

            Shuffle(cards);
            Cards = new Stack<Card>(cards);
        }

        public event EventHandler<DeckEmptyEventArgs> DeckEmpty;

        /// <summary>
        /// Raise the <see cref="DeckEmpty"/> event
        /// </summary>
        private void OnDeckEmpty()
        {
            DeckEmpty?.Invoke(this, new DeckEmptyEventArgs(this));
        }

        /// <summary>
        /// Shuffles the cards
        /// </summary>
        /// <param name="cards">The cards to shuffle</param>
        private void Shuffle(List<Card> cards)
        {
            Random random = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int randomNumber = random.Next(n + 1);
                Card card = cards[randomNumber];
                cards[randomNumber] = cards[n];
                cards[n] = card;
            }
        }

        public bool TryTakeCard(out Card card)
        {
            card = null;
            bool isEmpty = Cards.Count <= 0;
            if (isEmpty)
                OnDeckEmpty();

            card = Cards.Pop();
            bool cardWasTaken = !isEmpty;
            return cardWasTaken;
        }
    }
}
