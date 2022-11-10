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

        public int Value { get; private set; }

        public Player()
        {
            Hand = new List<Card>();
            HasStood = false;
            Value = 0;
        }

        public event EventHandler<PlayerHitEventArgs> PlayerHit;
        public event EventHandler<PlayerStoodEventArgs> PlayerStood;
        public event EventHandler<PlayerBustedEventArgs> PlayerBusted;

        protected void OnHit()
        {
            PlayerHit?.Invoke(this, new PlayerHitEventArgs(this, hit: true));
        }

        private void OnStood()
        {
            PlayerStood?.Invoke(this, new PlayerStoodEventArgs(this, stood: true));
        }

        protected void OnBusted()
        {
            PlayerBusted?.Invoke(this, new PlayerBustedEventArgs(this, busted: true));
        }

        public virtual void Hit()
        {
            Card card;
            bool cardWasTaken = Deck.Instance.TryTakeCard(out card);
            if (cardWasTaken)
            {
                Hand.Add(card);
                Value += card.Value;
                if(Value > Game.Target)
                {
                    Value -= 10;
                }

                if(Value > Game.Target)
                {
                    OnBusted();
                    return;
                }

                OnHit();           
            }
        }

        public void Stand()
        {
            HasStood = true;
            OnStood();
        }
    }
}
