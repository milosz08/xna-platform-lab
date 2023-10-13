using Microsoft.Xna.Framework;

namespace XnaZal1
{
    public class GameTile
    {
        private int _id, _number;
        private Rectangle _rect;
        private bool _isHovered;
        private int _rotateAngle;

        public GameTile(int id, int number, Rectangle rect)
        {
            _id = id;
            _number = number;
            _rect = rect;
        }

        public void SetSelectedNumber(GameTile tile)
        {
            _id = tile.Id;
            _number = tile.Number;
        }

        public void IncreaseRotateAngle()
        {
            if (_rotateAngle == 270)
            {
                _rotateAngle = 0;
            }
            else
            {
                _rotateAngle += 90;
            }
        }

        public void Reset()
        {
            _id = 0;
            _number = 0;
        }

        public int Id
        {
            get => _id;
            set { _id = value; }
        }

        public int Number
        {
            get => _number;
            set { _number = value; }
        }

        public Rectangle Rect
        {
            get => _rect;
            set { _rect = value; }
        }

        public bool IsHovered
        {
            get => _isHovered;
            set { _isHovered = value; }
        }

        public int RotateAngle
        {
            get => _rotateAngle;
            set { _rotateAngle = value; }
        }
    }
}
