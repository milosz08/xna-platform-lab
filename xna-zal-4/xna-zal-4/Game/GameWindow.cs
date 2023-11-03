using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaZal4
{
    public class GameWindow : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private GameState _state;
        private GameController _controller;
        private GameCanvas _canvas;

        public GameWindow()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1200;
            _graphics.PreferredBackBufferHeight = 900;

            Content.RootDirectory = "Content";

            IsMouseVisible = true;
            Window.AllowUserResizing = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _state = new GameState(this);
            _controller = new GameController(this, _state);
            _canvas = new GameCanvas(this, _state);
        }

        protected override void Update(GameTime gameTime)
        {
            _controller.ExitOnEsc();
            _controller.Interact();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.PaleTurquoise);

            _canvas.PerpareDrawer3D();
            _canvas.DrawAxisLines3D();
            _canvas.DrawRobotArms3D();

            base.Draw(gameTime);
        }
    }
}