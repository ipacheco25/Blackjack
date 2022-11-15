using Blackjack.Commands.Player;
using Blackjack.Events.PlayerEventArgs;
using Blackjack.Interfaces;
using Blackjack.Models;
using System.Collections.ObjectModel;

namespace Blackjack.ViewModels
{
    public class PlayerViewModel
    {
        public Player Player { get; private set; }

        public ObservableCollection<CardViewModel> Hand {get; private set; }

        public HitCommand Hit { get; private set; }
        public StandCommand Stand { get; private set; }

        private int _numOfCardsInHand;
        public PlayerViewModel(Player player)
        {
            Player = player;
            Hand = new ObservableCollection<CardViewModel>();
            Hit = new HitCommand(player);
            Stand = new StandCommand(player);

           _numOfCardsInHand = 0;
            foreach(Card card in player.Hand)
            {
                var cardViewModel = new CardViewModel(card);
                Hand.Add(cardViewModel);
                _numOfCardsInHand++;
            }

            Player.PlayerHit += Dealer_PlayerHit;
        }

        private void Dealer_PlayerHit(object sender, PlayerHitEventArgs e)
        {
            if(_numOfCardsInHand < e.Player.Hand.Count)
            {
                var cardViewModel = new CardViewModel(e.Card);
                Hand.Add(cardViewModel);
            }
        }
    }
}
