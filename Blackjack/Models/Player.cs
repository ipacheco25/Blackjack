using Blackjack.Enums;
using Blackjack.Events.PlayerEventArgs;
using Blackjack.Interfaces;
using System;
using System.Collections.Generic;

namespace Blackjack.Models
{
    public class Player : IPlayer
    {
        public List<Card> Hand { get; private set; }

        public bool HasStood { get; private set; }

        public bool HasBusted { get; private set; }

        public int Value { get; set; }

        public Player()
        {
            Hand = new List<Card>();
            HasStood = false;
            HasBusted = false;
            Value = 0;
        }

        public event EventHandler<PlayerHitEventArgs> PlayerHit;
        public event EventHandler<PlayerStoodEventArgs> PlayerStood;
        public event EventHandler<PlayerBustedEventArgs> PlayerBusted;

        private void OnHit(Card card)
        {
            PlayerHit?.Invoke(this, new PlayerHitEventArgs(this, card));
        }

        private void OnStood()
        {
            HasStood = true;
            PlayerStood?.Invoke(this, new PlayerStoodEventArgs(this, stood: true));
        }

        private void OnBusted()
        {
            HasBusted = true;
            PlayerBusted?.Invoke(this, new PlayerBustedEventArgs(this, busted: true));
        }

        public void Hit()
        {
            Card card;
            bool cardWasTaken = Deck.Instance.TryTakeCard(out card);
            if (cardWasTaken)
            {
                Hand.Add(card);
                Value += card.Value;
                if(card.Rank == ERanks.Ace && Value > Game.Target)
                {
                    Value -= 10;
                }
                OnHit(card);

                if (Value > Game.Target)
                {
                    OnBusted();
                }
            }
        }

        public void Stand()
        {
            OnStood();
        }
    }
}
