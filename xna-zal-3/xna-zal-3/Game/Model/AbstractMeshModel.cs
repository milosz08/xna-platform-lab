using Microsoft.Xna.Framework.Graphics;

namespace XnaZal3.Model
{
    public abstract class AbstractMeshModel<T>
    {
        protected VertexPositionColor[] _vertices;
        protected T _size;

        protected AbstractMeshModel(T size)
        {
            _vertices = new VertexPositionColor[8];
            _size = size;
        }

        public VertexPositionColor[] Vertices
        {
            get => _vertices;
        }

        public T Size
        {
            get => _size;
        }
    }
}
