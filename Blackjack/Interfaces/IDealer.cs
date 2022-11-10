using Blackjack.Models;

namespace Blackjack.Interfaces
{
    internal interface IDealer
    {
        /// <summary>
        /// Dealer will hit when the value is below this number
        /// </summary>
        int HitCeiling { get; }
        
        /// <summary>
        /// Deals two cards to the instance of <see cref="Player"/>
        /// </summary>
        /// <param name="player">The player to deal cards to</param>
        void DealCardsTo(Player player);
    }
}
