using Blackjack.Interfaces;

namespace Blackjack.Models
{
    public class Dealer : Player, IDealer
    {
        public int HitCeiling { get; }

        public Dealer()
        {
            HitCeiling = 16;
        }

        public void DealCardsTo(Player player)
        {
            int i = 0;
            int cardToDealPerPlayer = Game.InitalHandCount;
            do
            {
                Card card;
                bool cardWasTaken = Deck.Instance.TryTakeCard(out card);
                if (cardWasTaken)
                {
                    player.Hand.Add(card);
                }

                cardWasTaken = Deck.Instance.TryTakeCard(out card);
                if (cardWasTaken)
                {
                    Hand.Add(card);
                }
                i++;
            } while (i < cardToDealPerPlayer);
            
        }
    }
}
