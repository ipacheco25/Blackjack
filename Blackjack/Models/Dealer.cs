using Blackjack.Interfaces;

namespace Blackjack.Models
{
    internal class Dealer : Player, IDealer
    {
        public Dealer()
        {

        }

        public void DealCardsTo(Player player)
        {
            int i = 0;
            int cardToDealPerPlayer = 2;
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
