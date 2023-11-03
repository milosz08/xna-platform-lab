using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XnaZal4.Model;

namespace XnaZal4
{
    public class GameSimpleEffect : BasicEffect
    {
        private readonly GameWindow _game;
        private readonly GraphicsDevice _device;

        private Vector3 _cameraPosition = new(0, 0, 5);
        private Vector3 _cameraTarget = Vector3.Zero;

        public GameSimpleEffect(GameWindow game)
            : base(game.GraphicsDevice)
        {
            _game = game;
            _device = game.GraphicsDevice;
            VertexColorEnabled = true;
            InitMatrix();
        }

        public GameSimpleEffect(GameWindow game, string assetName)
            : base(game.GraphicsDevice)
        {
            _game = game;
            _device = game.GraphicsDevice;
            TextureEnabled = true;
            Texture = _game.Content.Load<Texture2D>(string.Format(@"{0}", assetName));
            EnableDefaultLighting();
            InitMatrix();
        }

        private void InitMatrix()
        {
            World = Matrix.Identity;
            View = Matrix.CreateLookAt(_cameraPosition, _cameraTarget, Vector3.Up);
            Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4,
                _device.Viewport.AspectRatio, 0.1f, 1000.0f);
        }

        public void DrawLinePrimitives(VertexPositionColor[] vertices)
        {
            foreach (EffectPass pass in CurrentTechnique.Passes)
            {
                pass.Apply();
                _device.DrawUserPrimitives(PrimitiveType.LineList,
                    vertices, 0, vertices.Length / 2);
            }
        }

        public void DrawTrianglePrimitives(AbstractCuboidModel cuboidModel)
        {
            foreach (EffectPass pass in CurrentTechnique.Passes)
            {
                pass.Apply();
                _device.DrawUserPrimitives(PrimitiveType.TriangleList,
                    cuboidModel.Vertices, 0, 12);
            }
        }
    }
}
