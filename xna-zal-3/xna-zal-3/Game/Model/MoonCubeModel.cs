using Microsoft.Xna.Framework;
using System;

namespace XnaZal3.Model
{
    public class MoonCubeModel : AbstractCubeModel
    {
        private static readonly float Y_APPROX = 4.0f; // nachylenie osi XZ

        private Vector2 _earthPos;

        public MoonCubeModel()
            : base(0.2f, 1.2f, 0.01f, 4.5f, 0.5f, Color.Silver, Color.Gray)
        {
            _earthPos = Vector2.Zero;
        }

        public override Matrix IncreaseAroundState()
        {
            if (_rotateAroundState >= 360)
            {
                _rotateAroundState = 0;
            }
            else
            {
                _rotateAroundState += _floatAroundSpeed;
            }
            float radians = MathHelper.ToRadians(_rotateAroundState);
            float x = _radius * (float)Math.Cos(radians);
            float y = (float)Math.Sin(radians) / Y_APPROX;
            float z = _radius * (float)Math.Sin(radians);
            return Matrix.CreateTranslation(x + _earthPos.X, y, z + _earthPos.Y);
        }

        public void SetEarhPos(Vector2 pos)
        {
            _earthPos.X = pos.X;
            _earthPos.Y = pos.Y;
        }

        public Vector2 EartPos
        {
            get => _earthPos;
        }
    }
}
