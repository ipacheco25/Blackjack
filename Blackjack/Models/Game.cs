using Blackjack.Enums;
using Blackjack.Events.GameEventArgs;
using Blackjack.Events.PlayerEventArgs;
using Blackjack.Interfaces;
using System;

namespace Blackjack.Models
{
    public class Game : IGame
    {
        public static readonly int Target = 21;
        public static readonly int InitalHandCount = 2;
        public Player Player { get; private set; }
        public Dealer Dealer { get; private set; }
        public EResults Results { get; private set; }

        public Game()
        {
            Player = new Player();
            Dealer = new Dealer();
            Results = EResults.InPlay;

            Player.PlayerBusted += Player_Busted;
            Dealer.PlayerBusted += Dealer_Busted;
            Player.PlayerStood += Player_Stood;
            Dealer.PlayerStood += Dealer_Stood;

            Dealer.DealCardsTo(Player);
        }

        private void Dealer_Stood(object sender, PlayerStoodEventArgs e)
        {
            if (Player.Value > Dealer.Value)
                OnGameEnded(results: EResults.Won);
            else if (Player.Value < Dealer.Value)
                OnGameEnded(results: EResults.Loss);
            else
                OnGameEnded(EResults.Tie);
        }

        private void Player_Stood(object sender, PlayerStoodEventArgs e)
        {
            while (!Dealer.HasBusted && Dealer.Value < Dealer.HitCeiling)
            {
                Dealer.Hit();
            }

            if (Dealer.HasBusted)
                return;

            Dealer.Stand();
        }

        public event EventHandler<GameEndedEventArgs> GameEnded;

        private void Dealer_Busted(object sender, PlayerBustedEventArgs e)
        {
            OnGameEnded(results: EResults.Won);
        }

        private void Player_Busted(object sender, PlayerBustedEventArgs e)
        {
            OnGameEnded(results: EResults.Loss);
        }

        private void OnGameEnded(EResults results)
        {
            Results = results;
            GameEnded?.Invoke(this, new GameEndedEventArgs(this, results));
        }
    }
}
