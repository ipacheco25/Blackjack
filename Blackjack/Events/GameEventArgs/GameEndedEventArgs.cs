using Blackjack.Enums;
using Blackjack.Models;

namespace Blackjack.Events.GameEventArgs
{
    internal class GameEndedEventArgs : GameEventArgs
    {
        public EGameResults Results { get; private set; }
        public GameEndedEventArgs(Game game, EGameResults results) : base(game)
        {
            Results = results;
        }
    }
}
