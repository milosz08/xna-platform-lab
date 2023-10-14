using Microsoft.Xna.Framework;

namespace XnaZal2.Sprite
{
    public abstract class Abstract2DAnimSprite : Abstract2DSprite
    {
        protected Rectangle[] _keyframes;
        protected int _keyframe;

        public Abstract2DAnimSprite(Rectangle pos, Rectangle[] keyframes)
            : base(pos)
        {
            _keyframes = keyframes;
            _keyframe = 0;
        }

        public virtual void Animate()
        {
            if (_keyframe == _keyframes.Length - 1)
            {
                _keyframe = 0;
            }
            else
            {
                _keyframe++;
            }
        }

        public Rectangle? GetCurrentKeyframe()
        {
            if (_keyframe == -1)
            {
                return null;
            }
            return _keyframes[_keyframe];
        }

        public int Keyframe
        {
            get => _keyframe;
        }
    }
}
