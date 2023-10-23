using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XnaZal3.Model;

namespace XnaZal3
{
    public class GameSimpleEffect : BasicEffect
    {
        private readonly GraphicsDevice _device;

        private Vector3 _cameraPosition = new(0, 0, 5);
        private Vector3 _cameraTarget = Vector3.Zero;

        public GameSimpleEffect(GraphicsDevice device) : base(device)
        {
            _device = device;
            VertexColorEnabled = true;
            World = Matrix.Identity;
            View = Matrix.CreateLookAt(_cameraPosition, _cameraTarget, Vector3.Up);
            Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4,
                _device.Viewport.AspectRatio, 0.1f, 100.0f);
        }

        public void DrawPrimitives(VertexPositionColor[] vertices)
        {
            foreach (EffectPass pass in CurrentTechnique.Passes)
            {
                pass.Apply();
                _device.DrawUserPrimitives(PrimitiveType.LineList,
                    vertices, 0, vertices.Length / 2);
            }
        }

        public void DrawIndexPrimitives(AbstractCubeModel cubeModel)
        {
            foreach (EffectPass pass in CurrentTechnique.Passes)
            {
                pass.Apply();
                _device.DrawUserIndexedPrimitives(PrimitiveType.TriangleList,
                    cubeModel.Vertices, 0, 8, cubeModel.CubeIndices, 0, 12);
            }
        }
    }
}
