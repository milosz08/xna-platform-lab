using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XnaZal2.Sprite;

namespace XnaZal2
{
    public class GameTexturesMap : AbstractGame
    {
        private readonly GameState _state;

        private Texture2D _background;
        private Texture2D _flameSpriteMap, _ballSpriteMap;
        private Texture2D _paddle1a, _paddle2a;
        private SpriteFont _spriteFont;
        private Point _paddleSize;

        private static readonly int BALL_KEYFRAMES_COUNT = 71;
        private static readonly int BALL_KEYFRAMES_COLS = 16;
        private static readonly int BALL_KEYFRAMES_ROWS = 5;
        private static readonly int FLAMES_KEYFRAMES_SIZE = 5;

        public GameTexturesMap(GameWindow game, GameState state) : base(game)
        {
            _state = state;
        }

        public void LoadTextures()
        {
            _background = LoadTexture("pongBackground");
            _flameSpriteMap = LoadTexture("explosion64");
            _ballSpriteMap = LoadTexture("ball-anim");
            _paddle1a = LoadTexture("paddle1a");
            _paddle2a = LoadTexture("paddle2a");
            _paddleSize = new Point(_paddle1a.Bounds.Size.X, _paddle1a.Bounds.Size.Y);
            _spriteFont = _game.Content.Load<SpriteFont>("font");
        }

        private Texture2D LoadTexture(string assetName)
        {
            return _game.Content.Load<Texture2D>(string.Format(@"{0}", assetName));
        }

        public void InitFlameSpriteMap()
        {
            Rectangle[] keyframes = new Rectangle[FLAMES_KEYFRAMES_SIZE * FLAMES_KEYFRAMES_SIZE];
            int size = _flameSpriteMap.Width / FLAMES_KEYFRAMES_SIZE;
            Rectangle pos = new(0, 0, size, size);
            int k = 0;
            for (int i = 0; i < FLAMES_KEYFRAMES_SIZE; i++)
            {
                for (int j = 0; j < FLAMES_KEYFRAMES_SIZE; j++)
                {
                    keyframes[k++] = new Rectangle(size * j, size * i, size, size);
                }
            }
            _state.FlameSprite = new FlameSprite(pos, keyframes);
        }

        public void InitBallSpriteMap()
        {
            Rectangle[] keyframes = new Rectangle[BALL_KEYFRAMES_COUNT];
            int size = _ballSpriteMap.Width / BALL_KEYFRAMES_COLS;
            Rectangle pos = new(
                _game.GraphicsDevice.Viewport.Width / 2 - size / 2,
                _game.GraphicsDevice.Viewport.Height / 2 - size / 2,
                size, size);
            int k = 0;
            for (int i = 0; i < BALL_KEYFRAMES_ROWS; i++)
            {
                for (int j = 0; j < BALL_KEYFRAMES_COLS; j++)
                {
                    if (k == BALL_KEYFRAMES_COUNT)
                    {
                        break;
                    }
                    keyframes[k++] = new Rectangle(size * j, size * i, size, size);
                }
            }
            _state.BallSprite = new BallSprite(pos, keyframes);
        }

        public Texture2D GetPaddle(PaddleLocation location)
        {
            if (location == PaddleLocation.LEFT)
            {
                return _paddle1a;
            }
            return _paddle2a;
        }

        public Texture2D Background
        {
            get => _background;
        }

        public Texture2D FlameSpriteMap
        {
            get => _flameSpriteMap;
        }

        public Texture2D BallSpriteMap
        {
            get => _ballSpriteMap;
        }

        public Point PaddleSize
        {
            get => _paddleSize;
        }

        public SpriteFont SpriteFont
        {
            get => _spriteFont;
        }
    }
}
