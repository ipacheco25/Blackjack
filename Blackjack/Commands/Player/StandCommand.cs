using Blackjack.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Blackjack.Commands.Player
{
    public class StandCommand : ICommand
    {
        private IPlayer _player;

        public StandCommand(IPlayer player)
        {
            _player = player;

            _player.PlayerStood += _player_PlayerStood;
            _player.PlayerBusted += _player_PlayerBusted;
        }

        private void _player_PlayerBusted(object sender, Events.PlayerEventArgs.PlayerBustedEventArgs e)
        {
            OnCanExecuteChanged();
        }

        private void _player_PlayerStood(object sender, Events.PlayerEventArgs.PlayerStoodEventArgs e)
        {
            OnCanExecuteChanged();
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !_player.HasStood && !_player.HasBusted;
        }

        public void Execute(object parameter)
        {
            _player.Stand();
        }

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
