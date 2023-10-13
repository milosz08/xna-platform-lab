using Microsoft.Xna.Framework.Graphics;

namespace XnaZal2
{
    public class GameCanvas : AbstractGame
    {
        private readonly GameController _controller;
        private readonly SpriteBatch _spriteBatch;

        public GameCanvas(GameWindow game, GameController controller, SpriteBatch spriteBatch) : base(game)
        {
            _controller = controller;
            _spriteBatch = spriteBatch;
        }
    }
}
