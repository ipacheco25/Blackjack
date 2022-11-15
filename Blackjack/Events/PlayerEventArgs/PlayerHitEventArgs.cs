using Blackjack.Interfaces;
using Blackjack.Models;

namespace Blackjack.Events.PlayerEventArgs
{
    public class PlayerHitEventArgs : PlayerEventArgs
    {
        public Card Card { get; }
        public int Index { get; }
        public PlayerHitEventArgs(IPlayer player, Card card, int index) : base(player)
        {
            Card = card;
            Index = index;
        }
    }
}
