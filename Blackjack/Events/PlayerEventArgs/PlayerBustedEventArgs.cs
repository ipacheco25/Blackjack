using Blackjack.Interfaces;

namespace Blackjack.Events.PlayerEventArgs
{
    public class PlayerBustedEventArgs : PlayerEventArgs
    {
        public bool Busted { get; }
        public PlayerBustedEventArgs(IPlayer player, bool busted) : base(player)
        {
            Busted = busted;
        }
    }
    
}
