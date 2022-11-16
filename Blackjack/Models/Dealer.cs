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
                player.Hit();
                Hit();
                i++;
            } while (i < cardToDealPerPlayer);
            
        }
    }
}
