using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using XnaZal2.Sprite;

namespace XnaZal2
{
    public class GameController : AbstractGame
    {
        private readonly GameState _state;

        public static readonly int HIGHLIGHT_TIME = 20;         // czas podświetlenia paletek
        public static readonly int BALL_MS_PER_FRAME = 50;     // szybkość animacji piłki
        public static readonly int FLAMES_MS_PER_FRAME = 100;   // szybkość animacji płomieni
        public static readonly int PADDLE_MOVE_SPEED = 4;       // prędkość poruszania paletkami
        public static readonly int BALL_VELOCITY = 3;           // prędkość początkowa piłki
        public static readonly int SWITCH_TOLERANCE = 50;

        private int _ballTimeSinceLastFrame = 0, _flamesTimeSinceLastFrame = 0;
        private bool _isGameStarted, _isIntersected;
        private Point _ballVelocity;
        private Rectangle _leftPaddleAABB = new(), _rightPaddleAABB = new();
        private int _timeRemaining = HIGHLIGHT_TIME;
        private Random _random = new();

        public GameController(GameWindow game, GameState state) : base(game)
        {
            _state = state;
            _ballVelocity = new(GenRandomVelocity(), GenRandomVelocity());
        }

        private int GenRandomVelocity()
        {
            return BALL_VELOCITY * (int)Math.Pow(-1, _random.Next(2));
        }

        private void ResetHighlight()
        {
            _state.RightPaddle.IsHighlight = false;
            _state.LeftPaddle.IsHighlight = false;
        }

        public void Interact(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (_isGameStarted)
            {
                CalculateBallPosition();
                AABBDetectCollision();
            }
            AnimateSprites(gameTime);
            MovePaddles(keyboardState);
            if (keyboardState.IsKeyDown(Keys.Space) && !_isGameStarted)
            {
                _isGameStarted = true;
            }
        }

        private void CalculateBallPosition()
        {
            int x = _state.BallSprite.Pos.X;
            int y = _state.BallSprite.Pos.Y;

            int maxWidth = _game.GraphicsDevice.Viewport.Width;
            int maxHeight = _game.GraphicsDevice.Viewport.Height;
            int ballWidth = _state.BallSprite.Pos.Width;
            int ballHeight = _state.BallSprite.Pos.Height;

            if (x > maxWidth / 2 - SWITCH_TOLERANCE && x < maxWidth / 2 + SWITCH_TOLERANCE)
            {
                _isIntersected = false;
            }
            if (x > maxWidth - ballWidth + GameCanvas.BALL_MARGIN
                || x < -GameCanvas.BALL_MARGIN)
            {
                if (x > maxWidth - ballWidth + GameCanvas.BALL_MARGIN)
                {
                    _state.LeftPaddle.IncreasePoints();
                }
                else
                {
                    _state.RightPaddle.IncreasePoints();
                }
                _state.FlameSprite.UpdatePos(x, y);
                x = maxWidth / 2 - ballWidth / 2;
                y = maxHeight / 2 - ballHeight / 2;
                _isGameStarted = false;
                _state.FlameSprite.IsExploded = true;
                _ballVelocity.X = GenRandomVelocity();
                _ballVelocity.Y = GenRandomVelocity();
                ResetHighlight();
                _isIntersected = false;
            }
            if (y > maxHeight - ballHeight + GameCanvas.BALL_MARGIN
                || y < -GameCanvas.BALL_MARGIN)
            {
                _ballVelocity.Y *= -1;
            }
            if (_isGameStarted)
            {
                x += _ballVelocity.X;
                y += _ballVelocity.Y;
            }
            _state.BallSprite.UpdatePos(x, y);
        }

        private void AABBDetectCollision()
        {
            if (--_timeRemaining == 0.0)
            {
                ResetHighlight();
            }
            RewritePaddlePosAndIntersect(_leftPaddleAABB, _state.LeftPaddle);
            RewritePaddlePosAndIntersect(_rightPaddleAABB, _state.RightPaddle);
        }

        private void RewritePaddlePosAndIntersect(Rectangle rewrite, PaddleSprite original)
        {
            rewrite.Width = original.Pos.Width;
            rewrite.Height = original.Pos.Height;
            rewrite.X = original.Pos.X + GameCanvas.BALL_MARGIN;
            rewrite.Y = original.Pos.Y + GameCanvas.BALL_MARGIN;
            if (original.Location == PaddleLocation.LEFT)
            {
                rewrite.X = original.Pos.X - GameCanvas.BALL_MARGIN;
                rewrite.Y = original.Pos.Y - GameCanvas.BALL_MARGIN;
            }
            if (_state.BallSprite.Pos.Intersects(rewrite) && !_isIntersected)
            {
                _ballVelocity.X = _ballVelocity.X < 0 ? _ballVelocity.X - 1 : _ballVelocity.X + 1;
                _ballVelocity.Y = _ballVelocity.Y < 0 ? _ballVelocity.Y - 1 : _ballVelocity.Y + 1;
                int delta = original.Pos.Y - _state.BallSprite.Pos.Center.Y;
                if (0 > delta && Math.Abs(delta) < original.Pos.Height)
                {
                    int currSector = Math.Abs(delta) / (original.Pos.Height / 5);
                    if (currSector == 0 || currSector == 4)
                    {
                        _ballVelocity.Y = _ballVelocity.Y < 0 ? 6 : -6;
                    }
                    else if (currSector == 1 || currSector == 3)
                    {
                        _ballVelocity.Y = _ballVelocity.Y < 0 ? 3 : -3;
                    }
                    else
                    {
                        _ballVelocity.Y = 0;
                    }
                }
                _isIntersected = true;
                _ballVelocity.X *= -1;
                _ballVelocity.Y *= -1;
                original.IsHighlight = true;
                _timeRemaining = HIGHLIGHT_TIME;
            }
        }

        private void AnimateSprites(GameTime gameTime)
        {
            _ballTimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            _flamesTimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (_ballTimeSinceLastFrame > BALL_MS_PER_FRAME)
            {
                _ballTimeSinceLastFrame -= BALL_MS_PER_FRAME;
                if (_state.FlameSprite.Keyframe != -1)
                {
                    _state.BallSprite.IsVisible = false;
                }
                else
                {
                    _state.BallSprite.IsVisible = true;
                    _state.BallSprite.Animate();
                }
            }
            if (_flamesTimeSinceLastFrame > FLAMES_MS_PER_FRAME)
            {
                _flamesTimeSinceLastFrame -= FLAMES_MS_PER_FRAME;
                _state.FlameSprite.Animate();
            }
        }

        private void MovePaddles(KeyboardState keyboardState)
        {
            int windowHeight = _game.GraphicsDevice.Viewport.Height;
            if (keyboardState.IsKeyDown(Keys.Q))
            {
                _state.LeftPaddle.GoUp();
            }
            else if (keyboardState.IsKeyDown(Keys.A))
            {
                _state.LeftPaddle.GoDown(windowHeight - _state.LeftPaddle.Pos.Height);
            }
            if (keyboardState.IsKeyDown(Keys.P))
            {
                _state.RightPaddle.GoUp();
            }
            else if (keyboardState.IsKeyDown(Keys.L))
            {
                _state.RightPaddle.GoDown(windowHeight - _state.RightPaddle.Pos.Height);
            }
        }

        public void ExitOnEsc()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                _game.Exit();
            }
        }
    }
}
