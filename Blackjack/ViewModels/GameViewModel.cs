using Blackjack.Commands.Game;
using Blackjack.Enums;
using Blackjack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Blackjack.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        private EGameResults _results;
        public EGameResults Results
        {
            get
            {
                return _results;
            }
            set
            {
                if (_results != value)
                {
                    _results = value;
                    OnPropertyChanged(nameof(Results));
                }

                if (_results != EGameResults.InPlay)
                    IsVisible = Visibility.Collapsed;
                else
                    IsVisible = Visibility.Visible;
            }
        }
        public DealerViewModel Dealer { get; set; }
        public PlayerViewModel Player { get; set; }

        public CloseCommand Close { get; set; }

        private Visibility _isVisible;
        public Visibility IsVisible
        {
            get
            {
                return _isVisible;
            }
            set
            {
                if (_isVisible != value)
                {
                    _isVisible = value;
                    OnPropertyChanged(nameof(IsVisible));
                }
            }
        }

        public GameViewModel(Game game)
        {
            DealerViewModel Dealer = new DealerViewModel(game.Dealer, game.Player);
            PlayerViewModel Player = new PlayerViewModel(game.Player);
            Close = new CloseCommand();
            _results = game.Results;
            _isVisible = Visibility.Collapsed;
            game.GameEnded += Game_GameEnded;
        }

        private void Game_GameEnded(object sender, Events.GameEventArgs.GameEndedEventArgs e)
        {
            Results = e.Results;
        }
    }
}
