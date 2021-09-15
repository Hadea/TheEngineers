using System.Collections.Generic;

namespace TicTacToeConsoleUI
{
    internal abstract class Scene
    {
        protected List<UIElement> uiElements = new();
        internal abstract void Update();
        internal virtual void Draw()
        {
            foreach (UIElement element in uiElements)
            {
                element.Draw();
            }
        }
    }
}
