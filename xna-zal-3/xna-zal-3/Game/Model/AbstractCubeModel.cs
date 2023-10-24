using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace XnaZal3.Model
{
    public abstract class AbstractCubeModel : AbstractMeshModel<float>
    {
        protected short[] _cubeIndices;
        protected Color _gradColor1, _gradColor2;
        protected float _radius;
        protected float _rotationSpeed;
        protected float _floatAroundSpeed;
        protected float _xDeviation;

        protected float _rotateAroundState = 0f, _rotateState = 0f;
        protected Matrix _rotatingState = Matrix.Identity;
        protected Vector2 _currentPos = Vector2.Zero;

        private Vector3[] _vertex;
        private readonly short[,] _cubeIndices2D = new short[6, 6]
        {
            { 0, 1, 2, 2, 1, 3 },
            { 1, 5, 3, 3, 5, 7 },
            { 5, 4, 7, 7, 4, 6 },
            { 4, 0, 6, 6, 0, 2 },
            { 2, 3, 6, 6, 3, 7 },
            { 4, 5, 0, 0, 5, 1 },
        };

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
            _cubeIndices = FlatCubeIndicatedArray();
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
                new Vector3(halfSize, -halfSize, -halfSize),
                new Vector3(-halfSize,halfSize, -halfSize),
                new Vector3(halfSize, halfSize, -halfSize),
                new Vector3(-halfSize, -halfSize, halfSize),
                new Vector3(halfSize, -halfSize, halfSize),
                new Vector3(-halfSize, halfSize, halfSize),
                new Vector3(halfSize, halfSize, halfSize),
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

        private short[] FlatCubeIndicatedArray()
        {
            short[] cubeIndices = new short[_cubeIndices2D.GetLength(0) *
                _cubeIndices2D.GetLength(1)];
            int k = 0;
            for (int i = 0; i < _cubeIndices2D.GetLength(0); i++)
            {
                for (int j = 0; j < _cubeIndices2D.GetLength(1); j++)
                {
                    cubeIndices[k++] = _cubeIndices2D[i, j];
                }
            }
            return cubeIndices;
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
