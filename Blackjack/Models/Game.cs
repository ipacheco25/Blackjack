using Blackjack.Enums;
using Blackjack.Events.GameEventArgs;
using Blackjack.Events.PlayerEventArgs;
using Blackjack.Interfaces;
using Blackjack.ViewModels;
using System;

namespace Blackjack.Models
{
    internal class Game : IGame
    {
        public PlayerViewModel Dealer { get; private set; }
        public PlayerViewModel Player { get; private set; }

        public static readonly int Target = 21;
        private Player _player;
        private Dealer _dealer;

        public Game()
        {
            _player = new Player();
            _dealer = new Dealer();

            _player.PlayerBusted += Player_Busted;
            _dealer.PlayerBusted += Dealer_Busted;
            _player.PlayerStood += Player_Stood;
            _dealer.PlayerStood += Dealer_Stood;

            _dealer.DealCardsTo(_player);

            Dealer = new PlayerViewModel(_dealer);
            Player = new PlayerViewModel(_player);
        }

        private void Dealer_Stood(object sender, PlayerStoodEventArgs e)
        {
            if (_player.Value > _dealer.Value)
                OnGameEnded(results: EGameResults.Won);
            else if (_player.Value < _dealer.Value)
                OnGameEnded(results: EGameResults.Loss);
            else
                OnGameEnded(EGameResults.Tie);
        }

        private void Player_Stood(object sender, PlayerStoodEventArgs e)
        {
            while (!_dealer.HasBusted && _dealer.Value < _dealer.HitCeiling)
            {
                _dealer.Hit();
            }

            if (_dealer.HasBusted)
                return;

            _dealer.Stand();
            
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
