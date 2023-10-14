using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaZal2
{
    public class GameWindow : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private GameState _state;
        private GameController _controller;
        private GameCanvas _canvas;

        public static readonly int WIDTH = 1024;
        public static readonly int HEIGHT = 768;

        public GameWindow()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = WIDTH;
            _graphics.PreferredBackBufferHeight = HEIGHT;

            Content.RootDirectory = "Content";
            Window.Title = "Pong";

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
            _state = new GameState();
            _controller = new GameController(this, _state);
            _canvas = new GameCanvas(this, _state, _spriteBatch);

            _canvas.LoadAndInitializedTextures();
            _canvas.InitPaddles();
        }

        protected override void Update(GameTime gameTime)
        {
            _controller.ExitOnEsc();
            _controller.Interact(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _canvas.DrawBackground();
            _canvas.DrawPaddles();
            _canvas.DrawBall();
            _canvas.DrawFlames();
            _canvas.DrawPointsInfo();
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}