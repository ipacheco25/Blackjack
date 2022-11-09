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

        public Stack<Card> Cards { get; private set; }

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

        private Deck()
        {
            List<Card> cards = Initialize();
            Shuffle(cards);
            Cards = new Stack<Card>(cards);
        }

        public event EventHandler<DeckEmptyEventArgs> DeckEmpty;

        private static List<Card> Initialize()
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
            return cards;
        }

        public void Shuffle(List<Card> cards)
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

        private void OnDeckEmpty()
        {
            DeckEmpty?.Invoke(this, new DeckEmptyEventArgs(this));
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
