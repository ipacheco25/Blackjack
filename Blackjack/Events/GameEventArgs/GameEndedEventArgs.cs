using Blackjack.Models;

namespace Blackjack.Events.GameEventArgs
{
    internal class GameEndedEventArgs : GameEventArgs
    {
        public bool? Won { get; private set; }
        public GameEndedEventArgs(Game game, bool? won) : base(game)
        {
            Won = won;
        }
    }
}
