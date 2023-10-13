using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaZal2
{
    public class GameWindow : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private GameController _gameController;
        private GameCanvas _gameCanvas;

        public GameWindow()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;

            Content.RootDirectory = "Content";

            IsMouseVisible = true;
            Window.AllowUserResizing = false;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _gameController = new GameController(this);
            _gameCanvas = new GameCanvas(this, _gameController, _spriteBatch);
        }

        protected override void Update(GameTime gameTime)
        {
            _gameController.ExitOnEsc();
            _gameController.Interact();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}