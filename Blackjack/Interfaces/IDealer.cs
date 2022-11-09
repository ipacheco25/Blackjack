using Blackjack.Models;

namespace Blackjack.Interfaces
{
    internal interface IDealer
    {
        /// <summary>
        /// Deals two cards to the instance of <see cref="Player"/>
        /// </summary>
        /// <param name="player">The player to deal cards to</param>
        void DealCardsTo(Player player);
    }
}
