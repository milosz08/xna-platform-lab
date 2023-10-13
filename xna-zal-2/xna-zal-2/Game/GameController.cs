using Microsoft.Xna.Framework.Input;
using System;

namespace XnaZal2
{
    public class GameController : AbstractGame
    {
        public GameController(GameWindow game) : base(game)
        {
        }

        public void Interact()
        {
        }

        public void ExitOnEsc()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                _game.Exit();
            }
        }
    }
}
