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

        Vector3[] frontFace;
        VertexPositionTexture[] userPrimitives;


        public GameSimpleEffect(GameWindow game, string assetName)
            : base(game.GraphicsDevice)
        {
            _game = game;
            _device = game.GraphicsDevice;

            frontFace = new Vector3[24];

            frontFace[0] = new Vector3(-1, -1, 0);
            frontFace[1] = new Vector3(-1, 1, 0);
            frontFace[2] = new Vector3(1, -1, 0);
            frontFace[3] = new Vector3(-1, 1, 0);
            frontFace[4] = new Vector3(1, 1, 0);
            frontFace[5] = new Vector3(1, -1, 0);

            frontFace[6] = new Vector3(-1, -1, 5);
            frontFace[7] = new Vector3(-1, 1, 5);
            frontFace[8] = new Vector3(1, -1, 5);
            frontFace[9] = new Vector3(-1, 1, 5);
            frontFace[10] = new Vector3(1, 1, 5);
            frontFace[11] = new Vector3(1, -1, 5);

            frontFace[12] = new Vector3(-1, -1, 0);
            frontFace[13] = new Vector3(-1, 1, 0);
            frontFace[14] = new Vector3(-1, -1, 5);
            frontFace[15] = new Vector3(-1, 1, 0);
            frontFace[16] = new Vector3(-1, 1, 5);
            frontFace[17] = new Vector3(-1, -1, 5);

            frontFace[18] = new Vector3(1, -1, 0);
            frontFace[19] = new Vector3(1, 1, 0);
            frontFace[20] = new Vector3(1, -1, 5);
            frontFace[21] = new Vector3(1, 1, 5);
            frontFace[22] = new Vector3(1, -1, 5);
            frontFace[23] = new Vector3(1, 1, 0);


            userPrimitives = new VertexPositionTexture[24];

            userPrimitives[0] = new VertexPositionTexture(frontFace[0], new Vector2(0, 4f));
            userPrimitives[1] = new VertexPositionTexture(frontFace[1], new Vector2(0, 0));
            userPrimitives[2] = new VertexPositionTexture(frontFace[2], new Vector2(4f, 4f));

            userPrimitives[3] = new VertexPositionTexture(frontFace[3], new Vector2(0, 0));
            userPrimitives[4] = new VertexPositionTexture(frontFace[4], new Vector2(4f, 0));
            userPrimitives[5] = new VertexPositionTexture(frontFace[5], new Vector2(4f, 4f));

            userPrimitives[6] = new VertexPositionTexture(frontFace[6], new Vector2(0, 1));
            userPrimitives[7] = new VertexPositionTexture(frontFace[7], new Vector2(0, 0));
            userPrimitives[8] = new VertexPositionTexture(frontFace[8], new Vector2(1, 1));

            userPrimitives[9] = new VertexPositionTexture(frontFace[9], new Vector2(0, 0));
            userPrimitives[10] = new VertexPositionTexture(frontFace[10], new Vector2(1, 0));
            userPrimitives[11] = new VertexPositionTexture(frontFace[11], new Vector2(1, 1));


            userPrimitives[12] = new VertexPositionTexture(frontFace[12], new Vector2(0, 2f));
            userPrimitives[13] = new VertexPositionTexture(frontFace[13], new Vector2(0, 0));
            userPrimitives[14] = new VertexPositionTexture(frontFace[14], new Vector2(2f, 2f));

            userPrimitives[15] = new VertexPositionTexture(frontFace[15], new Vector2(0, 0));
            userPrimitives[16] = new VertexPositionTexture(frontFace[16], new Vector2(2f, 0));
            userPrimitives[17] = new VertexPositionTexture(frontFace[17], new Vector2(2f, 2f));




            userPrimitives[18] = new VertexPositionTexture(frontFace[18], new Vector2(0, 1));
            userPrimitives[19] = new VertexPositionTexture(frontFace[19], new Vector2(0, 0));
            userPrimitives[20] = new VertexPositionTexture(frontFace[20], new Vector2(1, 1));

            userPrimitives[21] = new VertexPositionTexture(frontFace[21], new Vector2(0, 0));
            userPrimitives[22] = new VertexPositionTexture(frontFace[22], new Vector2(1, 0));
            userPrimitives[23] = new VertexPositionTexture(frontFace[23], new Vector2(1, 1));

            TextureEnabled = true;
            Texture = _game.Content.Load<Texture2D>(string.Format(@"{0}", assetName));


            //EnableDefaultLighting();
            InitMatrix();

        }

        private void InitMatrix()
        {
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

        public void DrawIndexPrimitives(AbstractCuboidModel cuboidModel)
        {
            foreach (EffectPass pass in CurrentTechnique.Passes)
            {
                pass.Apply();
                _device.DrawUserPrimitives(PrimitiveType.TriangleList,
                    userPrimitives, 0, 8);
            }
        }
    }
}
