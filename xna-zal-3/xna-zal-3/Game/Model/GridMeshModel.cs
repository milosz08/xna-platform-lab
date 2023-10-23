using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XnaZal3.Model;

namespace XnaZal3
{
    public class GridMeshModel : AbstractMeshModel<int>
    {
        private readonly Color _color;

        public GridMeshModel(int size, Color color)
            : base(size)
        {
            _color = color;
            InitMeshStructure();
        }

        public GridMeshModel()
            : this(50, Color.Gray)
        {
        }

        protected void InitMeshStructure()
        {
            _vertices = new VertexPositionColor[(_size + 1) * 4];
            for (int i = 0; i <= _size; i++)
            {
                float x = i - _size / 2.0f;
                _vertices[i * 4] = new VertexPositionColor(new Vector3(x, 0, -_size / 2.0f), _color);
                _vertices[i * 4 + 1] = new VertexPositionColor(new Vector3(x, 0, _size / 2.0f), _color);
                _vertices[i * 4 + 2] = new VertexPositionColor(new Vector3(-_size / 2.0f, 0, x), _color);
                _vertices[i * 4 + 3] = new VertexPositionColor(new Vector3(_size / 2.0f, 0, x), _color);
            }
        }
    }
}
