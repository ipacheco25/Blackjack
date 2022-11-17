using Blackjack.Commands.Player;
using Blackjack.Events.PlayerEventArgs;
using Blackjack.Interfaces;
using Blackjack.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Blackjack.ViewModels
{
    public class PlayerViewModel : BaseViewModel
    {
        public Player Player { get; private set; }

        public ObservableCollection<CardViewModel> Hand {get; private set; }

        public HitCommand Hit { get; private set; }
        public StandCommand Stand { get; private set; }

        private int _value;
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    OnPropertyChanged(nameof(Value));
                }
            }
        }

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
            Value = player.Value;

            player.PlayerHit += Dealer_PlayerHit;
        }

        internal virtual void Dealer_PlayerHit(object sender, PlayerHitEventArgs e)
        {
            if(e.Card != null)
            {
                var cardViewModel = new CardViewModel(e.Card);
                Hand.Add(cardViewModel);
                Value = Player.Value;
            }
        }
    }
}
