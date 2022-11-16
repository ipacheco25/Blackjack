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

        public PlayerViewModel(Player player)
        {
            Player = player;
            Hand = new ObservableCollection<CardViewModel>();
            Hit = new HitCommand(player);
            Stand = new StandCommand(player);

            foreach(Card card in player.Hand)
            {
                var cardViewModel = new CardViewModel(card);
                Hand.Add(cardViewModel);
            }

            Player.PlayerHit += Dealer_PlayerHit;
        }

        internal virtual void Dealer_PlayerHit(object sender, PlayerHitEventArgs e)
        {
            if(e.Card != null)
            {
                var cardViewModel = new CardViewModel(e.Card);
                Hand.Add(cardViewModel);
            }
        }
    }
}
