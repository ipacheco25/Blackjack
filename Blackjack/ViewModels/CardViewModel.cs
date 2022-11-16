using Blackjack.Enums;
using Blackjack.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Blackjack.ViewModels
{
    public class CardViewModel : INotifyPropertyChanged
    {
        private BitmapSource _front, _back, _image;
        public BitmapSource Image
        {
            get
            {
                return _image;
            }
            set
            {
                if (_image != value)
                {
                    _image = value;
                    OnPropertyChanged(nameof(Image));
                }
            }
        }

        public Card Card { get; private set; }

        public CardViewModel(Card card)
        {
            Card = card;

            string suit = "";
            switch (Card.Suit)
            {
                case ESuits.Club:
                    suit = "Clubs";
                    break;
                case ESuits.Spade:
                    suit = "Spades";
                    break;
                case ESuits.Diamond:
                    suit = "Diamonds";
                    break;
                default:
                    suit = "Hearts";
                    break;
            }

            string rank = "";
            switch (Card.Rank)
            {
                case ERanks.Ace:
                    rank = "Ace";
                    break;
                case ERanks.Two:
                    rank = "Two";
                    break;
                case ERanks.Three:
                    rank = "Three";
                    break;
                case ERanks.Four:
                    rank = "Four";
                    break;
                case ERanks.Five:
                    rank = "Five";
                    break;
                case ERanks.Six:
                    rank = "Six";
                    break;
                case ERanks.Seven:
                    rank = "Seven";
                    break;
                case ERanks.Eight:
                    rank = "Eight";
                    break;
                case ERanks.Nine:
                    rank = "Nine";
                    break;
                case ERanks.Ten:
                    rank = "Ten";
                    break;
                case ERanks.Jack:
                    rank = "Jack";
                    break;
                case ERanks.Queen:
                    rank = "Queen";
                    break;
                default:
                    rank = "King";
                    break;

            }

            var uriString = $"/Blackjack;component/Images/Cards/{suit}/{rank}.png";
            _front = new BitmapImage(new Uri(uriString, UriKind.Relative));

            uriString = $"/Blackjack;component/Images/Cards/{suit}/Back.png";
            _back = new BitmapImage(new Uri(uriString, UriKind.Relative));

            _image = _front;
        }

        public void ShowBack(bool showBack)
        {
            if (showBack)
                Image = _back;
            else
                Image = _front;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
