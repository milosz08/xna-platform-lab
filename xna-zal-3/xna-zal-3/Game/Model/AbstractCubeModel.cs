using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaZal3.Model
{
    public abstract class AbstractCubeModel : AbstractMeshModel<float>
    {
        protected short[] _cubeIndices;
        protected Color[] _colors;
        protected float _radius;
        protected float _rotationSpeed;
        protected float _floatAroundSpeed;
        protected float _xDeviation;

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
            float floatAroundSpeed, float xDeviation, Color[] colors)
            : base(cubeSize)
        {
            _radius = radius;
            _rotationSpeed = rotationSpeed;
            _floatAroundSpeed = floatAroundSpeed;
            _xDeviation = xDeviation;
            _colors = colors;
            InitMeshStructure();
            _cubeIndices = FlatCubeIndicatedArray();
        }

        protected AbstractCubeModel(float cubeSize, float rotationSpeed, float xDeviation,
            Color[] colors)
            : this(cubeSize, 0f, rotationSpeed, 0f, xDeviation, colors)
        {
        }

        private void InitMeshStructure()
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
            for (int i = 0; i < 8; i++)
            {
                _vertices[i] = new VertexPositionColor(_vertex[i], _colors[i]);
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

        public short[] CubeIndices
        {
            get => _cubeIndices;
        }

        public float Radius
        {
            get => _radius;
        }

        public float RotationSpeed
        {
            get => _rotationSpeed;
        }

        public float FloatAroundSpeed
        {
            get => _floatAroundSpeed;
        }

        public float XDeviation
        {
            get => _xDeviation;
        }
    }
}
