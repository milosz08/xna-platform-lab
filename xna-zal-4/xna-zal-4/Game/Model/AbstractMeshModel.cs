using Microsoft.Xna.Framework;

namespace XnaZal4.Model
{
    public abstract class AbstractMeshModel<T>
    {
        protected T[] _vertices;

        protected AbstractMeshModel(int vertices)
        {
            _vertices = new T[vertices];
        }

        public Matrix GenerateProjectionMatrix(GameWindow game)
        {
            return Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(50),
                game.GraphicsDevice.Viewport.AspectRatio, 0.1f, 1000.0f);
        }

        protected abstract void InitMeshStructure();

        public T[] Vertices
        {
            get => _vertices;
        }
    }
}
