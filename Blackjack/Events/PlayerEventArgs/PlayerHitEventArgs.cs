using Blackjack.Interfaces;
using Blackjack.Models;

namespace Blackjack.Events.PlayerEventArgs
{
    public class PlayerHitEventArgs : PlayerEventArgs
    {
        public Card Card { get; }
        public PlayerHitEventArgs(IPlayer player, Card card) : base(player)
        {
            Card = card;
        }
    }
}
