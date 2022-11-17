using Blackjack.Events.PlayerEventArgs;
using Blackjack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.ViewModels
{
    public class DealerViewModel : PlayerViewModel
    {
        public Dealer Dealer { get; private set; }

        public DealerViewModel(Dealer dealer) : base(dealer)
        {
            Dealer = dealer;
            ShowBackOfSecondCard(showBack: true);
        }

        public void ShowBackOfSecondCard(bool showBack = true)
        {
            var cardViewModel = Hand[Game.InitalHandCount - 1];
            cardViewModel.ShowBack(showBack);
        }

        internal override void Dealer_PlayerHit(object sender, PlayerHitEventArgs e)
        {
            if(Hand.Count == Game.InitalHandCount)
            {
                var cardViewModel = Hand[Hand.Count - 1];
                cardViewModel.ShowBack(false);
            }
            base.Dealer_PlayerHit(sender, e);
        }
    }
}
