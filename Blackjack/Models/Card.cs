using Blackjack.Enums;
using Blackjack.Interfaces;

namespace Blackjack.Models
{

    public class Card : ICard
    {
        public int Value { get; private set; }
        public ERanks Rank { get; private set; }
        public ESuits Suit { get; private set; }
        public EColors Color { get; private set; }

        public Card(ERanks rank, ESuits suit)
        {
            Rank = rank;
            Suit = suit;

            if (suit == ESuits.Spade || suit == ESuits.Club)
                Color = EColors.Black;
            else
                Color = EColors.Red;

            if(rank == ERanks.Ace)
            {
                Value = 11;
            }else if(rank == ERanks.Jack || rank == ERanks.Queen || rank == ERanks.King)
            {
                Value = 10;
            }
            else
            {
                Value = (int)rank;
            }
        }

        public bool SetValueOfAce(bool isOne)
        {
            if (Rank != ERanks.Ace)
                return false;

            Value = isOne ? 1 : 11;
            return true;
        }
    }
}