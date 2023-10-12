using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaZal1
{
    public class GameCanvas : AbstractGame
    {
        private readonly GameTexturesMap _gameTextureMap;
        private readonly GameController _gameController;
        private readonly SpriteBatch _spriteBatch;

        public static readonly int DEF_MARGIN = 10;
        public static readonly int GRID_ELEMENT_SIZE = 50;
        public static readonly int GRID_ELEMENTS = 10;
        public static readonly int MAX_NUMBER = 4;

        public GameCanvas(GameWindow game, GameController controller, SpriteBatch spriteBatch)
            : base(game)
        {
            _gameTextureMap = new GameTexturesMap(_game);
            _gameController = controller;
            _spriteBatch = spriteBatch;
        }

        public void InitLeftPickerTiles()
        {
            _gameController.LeftPickerTiles = new GameTile[MAX_NUMBER * 2];
            int defSize = GameTexturesMap.SPRITE_SIZE;
            int offset = DEF_MARGIN * 2 + defSize;
            int size = 50;
            int j = 1;
            for (int i = 0; i < _gameController.LeftPickerTiles.Length; i++)
            {
                _gameController.LeftPickerTiles[i] = new GameTile(i, j++,
                    new Rectangle(DEF_MARGIN, offset, size, size));
                if (j == 5)
                {
                    j = 1;
                }
                offset += size;
            }
            _gameController.SelectedTile = new GameTile(0, 0, new Rectangle(DEF_MARGIN,
                DEF_MARGIN, defSize, defSize));
        }

        public void DrawLeftPicker()
        {
            GameTile selected = _gameController.SelectedTile;
            if (selected.Number == 0)
            {
                _spriteBatch.Draw(_gameTextureMap.QuestionMark, selected.Rect, Color.White);
            }
            else
            {
                _spriteBatch.Draw(_gameTextureMap.NumbersMap, selected.Rect,
                    _gameTextureMap.GetTileSpriteBounds(selected.Id), Color.White);
            }
            foreach (GameTile number in _gameController.LeftPickerTiles)
            {
                _spriteBatch.Draw(_gameTextureMap.NumbersMap, number.Rect,
                    _gameTextureMap.GetTileSpriteBounds(number.Id),
                    number.IsHovered ? Color.LightGray : Color.White);
            }
        }

        public void InitGridTiles()
        {
            _gameController.GridTiles = new GameTile[GRID_ELEMENTS, GRID_ELEMENTS];
            for (int i = 0; i < _gameController.GridTiles.GetLength(0); i++)
            {
                for (int j = 0; j < _gameController.GridTiles.GetLength(1); j++)
                {
                    _gameController.GridTiles[i, j] = new GameTile(0, 0, GetGridRectangle(i, j));
                }
            }
        }

        public void DrawGrid()
        {
            Vector2 origin = new(GRID_ELEMENT_SIZE, GRID_ELEMENT_SIZE);
            for (int i = 0; i < _gameController.GridTiles.GetLength(0); i++)
            {
                for (int j = 0; j < _gameController.GridTiles.GetLength(1); j++)
                {
                    GameTile number = _gameController.GridTiles[i, j];
                    Texture2D renderedTexture;
                    Rectangle? innerRect = null;
                    number.Rect = GetGridRectangle(i, j);
                    if (number.Number == 0)
                    {
                        number.RotateAngle = 0;
                        renderedTexture = _gameTextureMap.QuestionMark;
                    }
                    else
                    {
                        renderedTexture = _gameTextureMap.NumbersMap;
                        innerRect = _gameTextureMap.GetTileSpriteBounds(number.Id);
                    }
                    _spriteBatch.Draw(renderedTexture, number.Rect, innerRect,
                        Color.White, MathHelper.ToRadians(number.RotateAngle), origin, SpriteEffects.None, 0);
                }
            }
        }

        private Rectangle GetGridRectangle(int x, int y)
        {
            int width = _game.GraphicsDevice.Viewport.Width - GameTexturesMap.SPRITE_SIZE - DEF_MARGIN;
            int size = GRID_ELEMENT_SIZE;
            int halfGridTile = GRID_ELEMENT_SIZE / 2;
            int spaceX = GameTexturesMap.SPRITE_SIZE + DEF_MARGIN;
            int startPointX = ((width - GRID_ELEMENT_SIZE * GRID_ELEMENTS) / 2) + spaceX + halfGridTile;
            if (((width - GRID_ELEMENT_SIZE * GRID_ELEMENTS) / 2) + spaceX <= spaceX)
            {
                startPointX = GameTexturesMap.SPRITE_SIZE + DEF_MARGIN * 2 + halfGridTile;
            }
            int startPointY = DEF_MARGIN + halfGridTile;
            return new Rectangle(startPointX + (x * size), startPointY + (y * size), size, size);
        }

        public void DrawBackground()
        {
            _spriteBatch.Draw(_gameTextureMap.Background, new Rectangle(0, 0,
                _game.GraphicsDevice.Viewport.Width,
                _game.GraphicsDevice.Viewport.Height), Color.White);
        }

        public void LoadAndInitializedTextures()
        {
            _gameTextureMap.LoadTextures();
            _gameTextureMap.LoadTextureMap();
        }
    }
}
