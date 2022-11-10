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
            OnGameEnded(won: true);
        }

        private void Player_Busted(object sender, PlayerBustedEventArgs e)
        {
            OnGameEnded(won: false);
        }

        private void OnGameEnded(bool? won)
        {
            GameEnded?.Invoke(this, new GameEndedEventArgs(this, won));
        }
    }
}
