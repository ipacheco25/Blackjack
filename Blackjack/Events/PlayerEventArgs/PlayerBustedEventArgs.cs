using Blackjack.Interfaces;

namespace Blackjack.Events.PlayerEventArgs
{
    internal class PlayerBustedEventArgs : PlayerEventArgs
    {
        public bool Busted { get; private set; }
        public PlayerBustedEventArgs(IPlayer player, bool busted) : base(player)
        {
            Busted = busted;
        }
    }
    
}
