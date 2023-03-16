namespace TicTacToe.Contracts
{
    public class GetGameByIdResponse
    {
        public int Id { get; set; }

        public string Board { get; set; } = null!;

        public string Message { get; set; } = null!;
    }
}
