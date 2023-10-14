using Microsoft.Xna.Framework;

namespace XnaZal2.Sprite
{
    public abstract class Abstract2DSprite
    {
        protected Rectangle _pos;

        protected Abstract2DSprite(Rectangle pos)
        {
            _pos = pos;
        }

        public void UpdatePos(int x, int y)
        {
            _pos.X = x;
            _pos.Y = y;
        }

        public Rectangle Pos
        {
            get => _pos;
        }
    }
}
