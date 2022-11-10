using Blackjack.Enums;
using Blackjack.Events.GameEventArgs;
using Blackjack.Events.PlayerEventArgs;
using Blackjack.Interfaces;
using System;

namespace Blackjack.Models
{
    internal class Game : IGame
    {
        public Dealer Dealer { get; private set; }
        public Player Player { get; private set; }

        public Game()
        {
            Player = new Player();
            Dealer = new Dealer();
            Player.Busted += Player_Busted;
            Dealer.Busted += Dealer_Busted;

            Dealer.DealCardsTo(Player);
        }

        public event EventHandler<GameEndedEventArgs> GameEnded;

        private void Dealer_Busted(object sender, PlayerBustedEventArgs e)
        {
            OnGameEnded(results: EGameResults.Won);
        }

        private void Player_Busted(object sender, PlayerBustedEventArgs e)
        {
            OnGameEnded(results: EGameResults.Loss);
        }

        private void OnGameEnded(EGameResults results)
        {
            GameEnded?.Invoke(this, new GameEndedEventArgs(this, results));
        }
    }
}
