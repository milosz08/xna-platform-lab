using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaZal3
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
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;

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
            _canvas = new GameCanvas(this, _state, _spriteBatch);

            _canvas.LoadTextures();
        }

        protected override void Update(GameTime gameTime)
        {
            _controller.Interact();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Transparent);

            _spriteBatch.Begin();
            _canvas.DrawBackground();
            _spriteBatch.End();

            _canvas.PerpareDrawer3D();
            _canvas.DrawGridMesh3D();
            _canvas.DrawPlanets3D();

            base.Draw(gameTime);
        }
    }
}