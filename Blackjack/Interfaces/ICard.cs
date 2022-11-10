using Blackjack.Enums;

namespace Blackjack.Interfaces
{
    internal interface ICard
    {
        /// <summary>
        /// The value of the Card
        /// </summary>
        int Value { get; }

        /// <summary>
        /// The rank of the Card
        /// </summary>
        ERanks Rank { get; }

        /// <summary>
        /// The suit of the Card
        /// </summary>
        ESuits Suit { get; }
    }
}
