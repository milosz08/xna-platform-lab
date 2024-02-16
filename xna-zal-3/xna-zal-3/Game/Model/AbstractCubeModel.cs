using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace XnaZal3.Model
{
    public abstract class AbstractCubeModel : AbstractMeshModel<float>
    {
        protected Color _gradColor1, _gradColor2;
        protected float _radius;
        protected float _rotationSpeed;
        protected float _floatAroundSpeed;
        protected float _xDeviation;

        protected float _rotateAroundState = 0f, _rotateState = 0f;
        protected Matrix _rotatingState = Matrix.Identity;
        protected Vector2 _currentPos = Vector2.Zero;

        protected readonly short[] _cubeIndices = new short[36]
        {
            0, 1, 2, 2, 3, 0,
            1, 5, 6, 6, 2, 1,
            5, 4, 7, 7, 6, 5,
            4, 0, 3, 3, 7, 4,
            4, 5, 1, 1, 0, 4,
            3, 2, 6, 6, 7, 3,
        };

        private Vector3[] _vertex;

        protected AbstractCubeModel(float cubeSize, float radius, float rotationSpeed,
            float floatAroundSpeed, float xDeviation, Color gradColor1, Color gradColor2)
            : base(cubeSize)
        {
            _radius = radius;
            _rotationSpeed = rotationSpeed;
            _floatAroundSpeed = floatAroundSpeed;
            _xDeviation = xDeviation;
            _gradColor1 = gradColor1;
            _gradColor2 = gradColor2;
            InitMeshStructure();
        }

        protected AbstractCubeModel(float cubeSize, float rotationSpeed, float xDeviation,
            Color gradColor1, Color gradColor2)
            : this(cubeSize, 0f, rotationSpeed, 0f, xDeviation, gradColor1, gradColor2)
        {
        }

        protected override void InitMeshStructure()
        {
            float halfSize = _size / 2;
            _vertex = new Vector3[8]
            {
                new Vector3(-halfSize, -halfSize, -halfSize),
                new Vector3(-halfSize, halfSize, -halfSize),
                new Vector3(halfSize,halfSize, -halfSize),
                new Vector3(halfSize, -halfSize, -halfSize),
                new Vector3(-halfSize, -halfSize, halfSize),
                new Vector3(-halfSize, halfSize, halfSize),
                new Vector3(halfSize, halfSize, halfSize),
                new Vector3(halfSize, -halfSize, halfSize),
            };
            Color[] colors = new Color[8]
            {
                _gradColor1,
                _gradColor2,
                _gradColor2,
                _gradColor1,
                _gradColor2,
                _gradColor1,
                _gradColor1,
                _gradColor2,
            };
            for (int i = 0; i < 8; i++)
            {
                _vertices[i] = new VertexPositionColor(_vertex[i], colors[i]);
            }
        }

        public virtual Matrix IncreaseRotateAroundState()
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
            _currentPos.X = _radius * (float)Math.Cos(radians);
            _currentPos.Y = _radius * 1.2f * (float)Math.Sin(radians);
            return Matrix.CreateTranslation(_currentPos.X, 0, _currentPos.Y);
        }

        public Matrix GenerateWorldMatrix()
        {
            if (_rotateState >= 360)
            {
                _rotateState = 0;
            }
            else
            {
                _rotateState++;
            }
            float radians = MathHelper.ToRadians(_rotateState);
            float x = _rotationSpeed * 1.2f * (float)Math.Cos(radians);
            return (_rotatingState *= Matrix.CreateRotationY(_rotationSpeed)
                * Matrix.CreateRotationX(x)) * IncreaseRotateAroundState();
        }

        public short[] CubeIndices
        {
            get => _cubeIndices;
        }

        public Vector2 CurrentPos
        {
            get => _currentPos;
        }
    }
}
