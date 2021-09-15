namespace TicTacToeConsoleUI
{
    internal abstract class UIElement
    {
        protected int posX;
        protected int posY;

        protected UIElement(int positionX, int positionY)
        {
            posX = positionX;
            posY = positionY;
        }

        internal abstract void Draw();
    }
}
