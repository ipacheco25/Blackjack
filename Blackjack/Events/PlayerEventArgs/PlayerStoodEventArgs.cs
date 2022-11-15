using Blackjack.Interfaces;

namespace Blackjack.Events.PlayerEventArgs
{
    public class PlayerStoodEventArgs : PlayerEventArgs
    {
        public bool Stood { get; }
        public PlayerStoodEventArgs(IPlayer player, bool stood) : base(player)
        {
            Stood = stood;
        }
    }
}
