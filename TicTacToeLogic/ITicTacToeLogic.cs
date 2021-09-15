
namespace TicTacToeLogic
{
    public interface ITicTacToeLogic
    {
        public bool CurrentPlayer { get; set; }
        public Field[,] GameBoard { get; init; }
        public TurnResult Turn(int X, int Y);
    }
}
