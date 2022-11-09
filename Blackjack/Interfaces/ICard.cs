namespace Blackjack.Interfaces
{
    internal interface ICard
    {
        /// <summary>
        /// Set the value of the card to either 1 or 11 if the card is an Ace
        /// </summary>
        /// <param name="isOne">Should be set to one</param>
        /// <returns>True if the card was an Ace. Otherwise, false.</returns>
        bool SetValueOfAce(bool isOne);
    }
}
