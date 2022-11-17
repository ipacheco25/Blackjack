using Blackjack.Models;
using Blackjack.ViewModels;
using System.Windows;

namespace Blackjack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Game game = new Game();
            GameViewModel gameViewModel = new GameViewModel(game);
            DealerControl.DataContext = gameViewModel.Dealer;
            PlayerControl.DataContext = gameViewModel.Player;
            ResultsControl.DataContext = gameViewModel;
        }
    }
}
