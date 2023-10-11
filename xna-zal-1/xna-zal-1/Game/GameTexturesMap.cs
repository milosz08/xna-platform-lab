using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaZal1
{
    public class GameTexturesMap : AbstractGame
    {
        public static readonly int SPRITE_SIZE = 100;

        private Texture2D _backgroundTexture, _numbersMapTexture, _questionMarkTexture;
        private Texture2D[] _tileSprites;

        public GameTexturesMap(GameWindow game) : base(game)
        {
        }

        public void LoadTextures()
        {
            _backgroundTexture = _game.Content.Load<Texture2D>(@"background");
            _numbersMapTexture = _game.Content.Load<Texture2D>(@"numbers");
            _questionMarkTexture = _game.Content.Load<Texture2D>(@"question");
        }

        public Texture2D GetTileSprite(int id)
        {
            if (id > _tileSprites.Length - 1 || id < 0)
            {
                return new Texture2D(_game.GraphicsDevice, SPRITE_SIZE, SPRITE_SIZE);
            }
            return _tileSprites[id];
        }

        public void LoadTextureMap()
        {
            int countOfCols = _numbersMapTexture.Bounds.Width / SPRITE_SIZE;
            int countOfRows = _numbersMapTexture.Bounds.Height / SPRITE_SIZE;
            _tileSprites = new Texture2D[countOfCols * countOfRows];
            int k = 0;
            for (int i = 0; i < countOfRows; i++)
            {
                for (int j = 0; j < countOfCols; j++)
                {
                    _tileSprites[k] = new Texture2D(_game.GraphicsDevice, SPRITE_SIZE, SPRITE_SIZE);
                    Rectangle coords = new Rectangle(j * SPRITE_SIZE, i * SPRITE_SIZE,
                        SPRITE_SIZE, SPRITE_SIZE);
                    int spriteSize = SPRITE_SIZE * SPRITE_SIZE;
                    Color[] data = new Color[spriteSize];
                    _numbersMapTexture.GetData(0, coords, data, 0, spriteSize);
                    _tileSprites[k].SetData(data);
                    k++;
                }
            }
        }

        public Texture2D Background
        {
            get => _backgroundTexture;
        }

        public Texture2D NumbersMap
        {
            get => _numbersMapTexture;
        }

        public Texture2D QuestionMark
        {
            get => _questionMarkTexture;
        }
    }
}
