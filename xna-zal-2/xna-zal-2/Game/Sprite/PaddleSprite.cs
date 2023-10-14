using Microsoft.Xna.Framework;

namespace XnaZal2.Sprite
{
    public enum PaddleLocation
    {
        LEFT, RIGHT
    }

    public class PaddleSprite
    {
        private Rectangle _pos;
        private bool _isHighlight;
        private int _points;
        private PaddleLocation _location;

        public PaddleSprite(Rectangle pos, PaddleLocation location)
        {
            _pos = pos;
            _isHighlight = false;
            _points = 0;
            _location = location;
        }

        public void GoUp()
        {
            if (_pos.Y > 0)
            {
                _pos.Y -= GameController.PADDLE_MOVE_SPEED;
            }
        }

        public void GoDown(int maxWidth)
        {
            if (_pos.Y < maxWidth)
            {
                _pos.Y += GameController.PADDLE_MOVE_SPEED;
            }
        }

        public void IncreasePoints()
        {
            _points++;
        }

        public Rectangle Pos
        {
            get => _pos;
        }

        public bool IsHighlight
        {
            get => _isHighlight;
            set { _isHighlight = value; }
        }

        public int Points
        {
            get => _points;
        }

        public PaddleLocation Location
        {
            get => _location;
        }
    }
}
