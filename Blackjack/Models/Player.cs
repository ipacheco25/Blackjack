using Blackjack.Enums;
using Blackjack.Events.PlayerEventArgs;
using Blackjack.Interfaces;
using System;
using System.Collections.Generic;

namespace Blackjack.Models
{
    internal class Player : IPlayer
    {
        public List<Card> Hand { get; private set; }

        public bool HasStood { get; private set; }

        public int NumberOfAcesInHand { get; private set; }

        public int Count { get; private set; }

        public Player()
        {
            Hand = new List<Card>();
            HasStood = false;
            NumberOfAcesInHand = 0;
            Count = 0;
        }

        public event EventHandler<PlayerHitEventArgs> Hitted;
        public event EventHandler<PlayerStoodEventArgs> Stood;
        public event EventHandler<PlayerBustedEventArgs> Busted;

        protected void OnHit()
        {
            Hitted?.Invoke(this, new PlayerHitEventArgs(this, hit: true));
        }

        private void OnStood()
        {
            Stood?.Invoke(this, new PlayerStoodEventArgs(this, stood: true));
        }

        protected void OnBusted()
        {
            Busted?.Invoke(this, new PlayerBustedEventArgs(this, busted: true));
        }

        public virtual void Hit()
        {
            Card card;
            bool cardWasTaken = Deck.Instance.TryTakeCard(out card);
            if (cardWasTaken)
            {
                Hand.Add(card);
                OnHit();
                if (card.Rank != ERanks.Ace)
                {
                    Count += card.Value;
                    CheckIfHandHasBusted();
                }
                else
                {
                    NumberOfAcesInHand += 1;
                    CheckIfHandHasBusted();
                }
                
            }
        }

        public void Stand()
        {
            HasStood = true;
            OnStood();
        }

        public void CalculateHand()
        {
            //Logic to determine best hand goes here
        }

        private bool CheckIfHandHasBusted()
        {
            int target = 21;
            if (Count > target)
                return true;
            else
            {
                return false;
            }
        }
    }
}
