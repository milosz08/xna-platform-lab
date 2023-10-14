using Microsoft.Xna.Framework;

namespace XnaZal2.Sprite
{
    public class BallSprite : Abstract2DAnimSprite
    {
        private bool _isVisible;

        public BallSprite(Rectangle pos, Rectangle[] keyframes)
            : base(pos, keyframes)
        {
            _isVisible = true;
        }

        public bool IsVisible
        {
            get => _isVisible;
            set { _isVisible = value; }
        }
    }
}
