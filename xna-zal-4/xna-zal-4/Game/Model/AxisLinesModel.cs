using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaZal4.Model
{
    public class AxisLinesModel
        : AbstractMeshModel<VertexPositionColor>
    {
        private readonly Color _xColor, _yColor, _zColor;
        private readonly int _size = 6;

        public AxisLinesModel(Color xColor, Color yColor, Color zColor)
            : base(6)
        {
            _xColor = xColor;
            _yColor = yColor;
            _zColor = zColor;
            InitMeshStructure();
        }

        public AxisLinesModel()
            : this(Color.Red, Color.Green, Color.Blue)
        {
        }

        protected override void InitMeshStructure()
        {
            _vertices[0] = new VertexPositionColor(-_size * Vector3.UnitX, _xColor);
            _vertices[1] = new VertexPositionColor(_size * Vector3.UnitX, _xColor);

            _vertices[2] = new VertexPositionColor(-_size * Vector3.UnitY, _yColor);
            _vertices[3] = new VertexPositionColor(_size * Vector3.UnitY, _yColor);

            _vertices[4] = new VertexPositionColor(-_size * Vector3.UnitZ, _zColor);
            _vertices[5] = new VertexPositionColor(_size * Vector3.UnitZ, _zColor);
        }
    }
}
