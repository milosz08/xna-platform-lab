using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XnaZal2.Sprite;

namespace XnaZal2
{
    public class GameCanvas : AbstractGame
    {
        private readonly GameState _state;
        private readonly GameTexturesMap _texturesMap;
        private readonly SpriteBatch _spriteBatch;

        public static readonly int FONT_MARGIN = 10;
        public static readonly int BALL_MARGIN = 10;

        public GameCanvas(GameWindow game, GameState state, SpriteBatch spriteBatch)
            : base(game)
        {
            _texturesMap = new GameTexturesMap(game, state);
            _state = state;
            _spriteBatch = spriteBatch;
        }

        public void DrawPaddle(PaddleSprite sprite)
        {
            Point size = _texturesMap.PaddleSize;
            int posX = GetPaddleXPos(sprite.Location);
            _spriteBatch.Draw(_texturesMap.GetPaddle(sprite.Location),
                new Rectangle(posX, sprite.Pos.Y, size.X, size.Y),
                sprite.IsHighlight ? Color.LightGreen : Color.White);
        }

        public PaddleSprite InitPaddle(PaddleLocation location)
        {
            Point size = _texturesMap.PaddleSize;
            int posX = GetPaddleXPos(location);
            int posY = _game.GraphicsDevice.Viewport.Height / 2 - size.Y / 2;
            return new PaddleSprite(new Rectangle(posX, posY, size.X, size.Y), location);
        }

        public int GetPaddleXPos(PaddleLocation location)
        {
            Point size = _texturesMap.PaddleSize;
            if (location == PaddleLocation.RIGHT)
            {
                return _game.GraphicsDevice.Viewport.Width - size.X;
            }
            return 0;
        }

        public void DrawPaddles()
        {
            DrawPaddle(_state.LeftPaddle);
            DrawPaddle(_state.RightPaddle);
        }

        public void InitPaddles()
        {
            _state.LeftPaddle = InitPaddle(PaddleLocation.LEFT);
            _state.RightPaddle = InitPaddle(PaddleLocation.RIGHT);
        }

        public void DrawBall()
        {
            if (_state.BallSprite.IsVisible)
            {
                _spriteBatch.Draw(_texturesMap.BallSpriteMap, _state.BallSprite.Pos,
                    _state.BallSprite.GetCurrentKeyframe(), Color.White);
            }
        }

        public void DrawFlames()
        {
            Rectangle? keyframe = _state.FlameSprite.GetCurrentKeyframe();
            if (keyframe != null)
            {
                _spriteBatch.Draw(_texturesMap.FlameSpriteMap, _state.FlameSprite.Pos,
                    _state.FlameSprite.GetCurrentKeyframe(), Color.White);
            }
        }

        public void DrawPointsInfo()
        {
            string points = $"{FormatPoints(_state.LeftPaddle)}  " +
                $"{FormatPoints(_state.RightPaddle)}";
            int xOffset = (int)_texturesMap.SpriteFont.MeasureString(points).X / 2;
            _spriteBatch.DrawString(_texturesMap.SpriteFont, points,
                new Vector2(_game.GraphicsDevice.Viewport.Width / 2 - xOffset, FONT_MARGIN),
                Color.LightBlue);
        }

        private static string FormatPoints(PaddleSprite sprite)
        {
            return sprite.Points.ToString("D2");
        }

        public void DrawBackground()
        {
            _spriteBatch.Draw(_texturesMap.Background, new Rectangle(0, 0,
                _game.GraphicsDevice.Viewport.Width,
                _game.GraphicsDevice.Viewport.Height), Color.White);
        }

        public void LoadAndInitializedTextures()
        {
            _texturesMap.LoadTextures();
            _texturesMap.InitFlameSpriteMap();
            _texturesMap.InitBallSpriteMap();
        }
    }
}
