
namespace TicTacToe.Models
{
    public class Game
    {
        private string _board = new(' ', 9);

        public int Id { get; set; }

        public string Board
        {
            get => _board;
            set
            {
                if (value.Any(x => x != 'X' && x != 'O' && x != ' '))
                    throw new ArgumentException("Non-valid symbol");

                _board = value;
            }
        }
    }
}
