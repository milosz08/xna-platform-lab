using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaZal4.Model
{
    public class AxisData
    {
        public Vector3 Vector { get; set; }
        public Color Color { get; set; }

        public AxisData(Vector3 vector, Color color)
        {
            Vector = vector;
            Color = color;
        }
    }

    public class AxisLinesModel
        : AbstractMeshModel<VertexPositionColor>
    {
        private readonly int _size = 6;
        private readonly AxisData[] _helpAxisData = new AxisData[3];

        public AxisLinesModel(Color xColor, Color yColor, Color zColor)
            : base(6)
        {
            _helpAxisData[0] = new AxisData(Vector3.UnitX, xColor);
            _helpAxisData[1] = new AxisData(Vector3.UnitY, yColor);
            _helpAxisData[2] = new AxisData(Vector3.UnitZ, zColor);
            InitMeshStructure();
        }

        public AxisLinesModel()
            : this(Color.Red, Color.Green, Color.Blue)
        {
        }

        protected override void InitMeshStructure()
        {
            int j = 0;
            for (int i = 0; i < _helpAxisData.Length * 2; i++)
            {
                int size = i % 2 == 0 ? -_size : _size;
                int index = i % 2 == 0 && i != 0 ? ++j : j;
                _vertices[i] = new VertexPositionColor(size * _helpAxisData[index].Vector,
                    _helpAxisData[index].Color);
            }
        }
    }
}
