using Blackjack.Enums;
using Blackjack.Interfaces;

namespace Blackjack.Events.GameEventArgs
{
    public class GameEndedEventArgs : GameEventArgs
    {
        public EResults Results { get; }
        public GameEndedEventArgs(IGame game, EResults results) : base(game)
        {
            Results = results;
        }
    }
}
