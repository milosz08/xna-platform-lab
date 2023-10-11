using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace XnaZal1
{
    public class GameController : AbstractGame
    {
        private float _timeRemaining = 0.0f;
        private readonly static float TIME_PER_SPRITE = 5.0f;

        private GameTile[] _leftPickerTiles;
        private GameTile[,] _gridTiles;
        private GameTile _selectedTile;

        private Vector2 dim = new();
        private Vector2 size = new();
        private Vector2 bounds = new();
        private Vector2 pos = new();

        public GameController(GameWindow game) : base(game)
        {
        }

        public void Interact(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            Point mousePos = new(mouseState.X, mouseState.Y);
            if (_timeRemaining == 0.0f)
            {
                if (_selectedTile.Rect.Contains(mousePos))
                {
                    _selectedTile.Reset();
                }

                dim.X = mousePos.X - GameCanvas.DEF_MARGIN;
                dim.Y = mousePos.Y - (GameCanvas.DEF_MARGIN * 2 + GameTexturesMap.SPRITE_SIZE);
                size.X = GameCanvas.GRID_ELEMENT_SIZE;
                size.Y = GameCanvas.GRID_ELEMENT_SIZE * GameCanvas.MAX_NUMBER * 2;
                bounds.X = 1;
                bounds.Y = GameCanvas.MAX_NUMBER * 2;

                if (HasIntersectSelection())
                {
                    _selectedTile.IsHovered = true;
                    _selectedTile.SetSelectedNumber(_leftPickerTiles[(int)pos.Y]); ;
                }

                int spaceX = GameTexturesMap.SPRITE_SIZE + GameCanvas.DEF_MARGIN;
                int containerWidth = _game.GraphicsDevice.Viewport.Width - GameTexturesMap.SPRITE_SIZE - GameCanvas.DEF_MARGIN;
                int gridSize = GameCanvas.GRID_ELEMENT_SIZE * GameCanvas.GRID_ELEMENTS;

                dim.X = mousePos.X - (((containerWidth - GameCanvas.GRID_ELEMENT_SIZE * GameCanvas.GRID_ELEMENTS) / 2) + spaceX);
                dim.Y = mousePos.Y - GameCanvas.DEF_MARGIN;
                size.X = gridSize;
                size.Y = gridSize;
                bounds.X = GameCanvas.GRID_ELEMENTS;
                bounds.Y = GameCanvas.GRID_ELEMENTS;

                if (HasIntersectSelection())
                {
                    GameTile gridPickTile = _gridTiles[(int)pos.X, (int)pos.Y];
                    gridPickTile.SetSelectedNumber(_selectedTile);

                    // TODO: add element rotation
                }

                _timeRemaining = TIME_PER_SPRITE;
            }
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                _timeRemaining = 0.0f;
            }
            foreach (GameTile tile in _leftPickerTiles)
            {
                tile.IsHovered = tile.Rect.Contains(mousePos);
            }
            _timeRemaining = MathHelper.Max(0, _timeRemaining - (float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        private bool HasIntersectSelection()
        {
            if (dim.X >= 0 && dim.X <= size.X && dim.Y >= 0 && dim.Y <= size.Y)
            {
                pos.X = (int)dim.X / GameCanvas.GRID_ELEMENT_SIZE;
                pos.Y = (int)dim.Y / GameCanvas.GRID_ELEMENT_SIZE;
                return pos.X >= 0 && pos.X < bounds.X && pos.Y >= 0 && pos.Y < bounds.Y;
            }
            return false;
        }

        public void ExitOnEsc()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                _game.Exit();
            }
        }

        public GameTile[] LeftPickerTiles
        {
            get => _leftPickerTiles;
            set { _leftPickerTiles = value; }
        }

        public GameTile SelectedTile
        {
            get => _selectedTile;
            set { _selectedTile = value; }
        }

        public GameTile[,] GridTiles
        {
            get => _gridTiles;
            set { _gridTiles = value; }
        }
    }
}
