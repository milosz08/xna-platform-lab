using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaZal1
{
    public class GameTexturesMap : AbstractGame
    {
        public static readonly int SPRITE_SIZE = 100;

        private Texture2D _backgroundTexture, _numbersMapTexture, _questionMarkTexture;
        private Rectangle[] _tileSprites;

        public GameTexturesMap(GameWindow game) : base(game)
        {
        }

        public void LoadTextures()
        {
            _backgroundTexture = _game.Content.Load<Texture2D>(@"background");
            _numbersMapTexture = _game.Content.Load<Texture2D>(@"numbers");
            _questionMarkTexture = _game.Content.Load<Texture2D>(@"question");
        }

        public Rectangle GetTileSpriteBounds(int id)
        {
            if (id > _tileSprites.Length - 1 || id < 0)
            {
                return new Rectangle(0, 0, SPRITE_SIZE, SPRITE_SIZE);
            }
            return _tileSprites[id];
        }

        public void LoadTextureMap()
        {
            int countOfCols = _numbersMapTexture.Bounds.Width / SPRITE_SIZE;
            int countOfRows = _numbersMapTexture.Bounds.Height / SPRITE_SIZE;
            _tileSprites = new Rectangle[countOfCols * countOfRows];
            int k = 0;
            for (int i = 0; i < countOfRows; i++)
            {
                for (int j = 0; j < countOfCols; j++)
                {
                    _tileSprites[k++] = new Rectangle(j * SPRITE_SIZE, i * SPRITE_SIZE,
                        SPRITE_SIZE, SPRITE_SIZE);
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
