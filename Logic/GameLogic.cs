using System.Runtime.CompilerServices;
using TicTacToe.Contracts;
using TicTacToe.Models;

namespace TicTacToe.Logic
{
    public static class GameLogic
    {
        public static bool NextTurnIsX(this Game game)
            => game.Board.Count(x => x == 'X') == game.Board.Count(x => x == 'O');

        public static string NextTurnMessage(this Game game)
            => game.NextTurnIsX()
                ? "Next turn is X."
                : "Next turn is O.";

        public static string MakeTurn(this Game game, MakeTurnCommand command, out bool gameOver)
        {
            gameOver = false;
            
            var newBoard = game.Board.ToCharArray();
            newBoard[command.SpaceNumber] = command.IsX
                ? 'X' : 'O';

            var possibleWinner = CheckWinner(newBoard);

            game.Board = new string(newBoard);

            if (possibleWinner == default && game.Board.Any(x => x == ' '))
                return game.NextTurnMessage();

            gameOver = true;
            if (possibleWinner == default)
                return "Draw.";
            
            return $"{possibleWinner} is winner";

            char CheckWinner(char[] board)
            {
                //horizontal
                for (int i = 0; i < 9; i += 3)
                    if (board[i] != ' ' && board[i] == board[i + 1] && board[i] == board[i + 2])
                        return board[i];

                //vertical
                for (int i = 0; i < 3; i++)
                    if (board[i] != ' ' && board[i] == board[i + 3] && board[i] == board[i + 6])
                        return board[i];

                //diagonal
                if (board[4] != ' ' && (board[0] == board[4] && board[4] == board[8]
                   || board[2] == board[4] && board[4] == board[6]))
                    return board[4];

                return default;
            }
        }



        
    }
}
