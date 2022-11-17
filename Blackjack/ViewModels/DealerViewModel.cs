using Blackjack.Events.PlayerEventArgs;
using Blackjack.Models;

namespace Blackjack.ViewModels
{
    public class DealerViewModel : PlayerViewModel
    {
        public Dealer Dealer { get; private set; }

        public DealerViewModel(Dealer dealer, Player player) : base(dealer)
        {
            Dealer = dealer;
            ShowBackOfSecondCard(showBack: true);

            player.PlayerStood += Player_PlayerStood;
        }

        private void Player_PlayerStood(object sender, PlayerStoodEventArgs e)
        {
            ShowBackOfSecondCard(showBack:false);
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
