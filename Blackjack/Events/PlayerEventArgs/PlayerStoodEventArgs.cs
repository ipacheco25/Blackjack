using Blackjack.Interfaces;

namespace Blackjack.Events.PlayerEventArgs
{
    internal class PlayerStoodEventArgs : PlayerEventArgs
    {
        public bool Stood { get; }
        public PlayerStoodEventArgs(IPlayer player, bool stood) : base(player)
        {
            Stood = stood;
        }
    }
}
