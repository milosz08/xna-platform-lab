using Microsoft.Xna.Framework;

namespace XnaZal2.Sprite
{
    public class FlameSprite : Abstract2DAnimSprite
    {
        public FlameSprite(Rectangle pos, Rectangle[] keyframes)
            : base(pos, keyframes)
        {
            _keyframe = -1;
        }

        public override void Animate()
        {
            if (_keyframe == -1)
            {
                return;
            }
            base.Animate();
            if (_keyframe == 0)
            {
                _keyframe = -1;
            }
        }

        public bool IsExploded
        {
            get => _keyframe != -1;
            set { _keyframe = value ? 0 : -1; }
        }
    }
}
