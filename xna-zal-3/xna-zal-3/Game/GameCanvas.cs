using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaZal3
{
    public class GameCanvas : AbstractGame
    {
        private readonly GameTexturesMap _texturesMap;
        private readonly SpriteBatch _spriteBatch;

        public GameCanvas(GameWindow game, GameState state, SpriteBatch spriteBatch)
            : base(game, state)
        {
            _texturesMap = new GameTexturesMap(game, state);
            _spriteBatch = spriteBatch;
        }

        public void DrawBackground()
        {
            if (_state.EmptyBackground)
            {
                _game.GraphicsDevice.Clear(Color.Honeydew);
            }
            else
            {
                _spriteBatch.Draw(_texturesMap.Background, new Rectangle(0, 0,
                   _game.GraphicsDevice.Viewport.Width,
                   _game.GraphicsDevice.Viewport.Height), Color.White);
            }
        }

        public void DrawGridMesh3D()
        {
            if (!_state.HideMesh)
            {
                _state.MeshEffect.DrawPrimitives(_state.GridMeshModel.Vertices);
            }
        }

        public void DrawPlanets3D()
        {
            _state.SunCubeEffect.DrawIndexPrimitives(_state.SunCubeModel);
            _state.MercuryCubeEffect.DrawIndexPrimitives(_state.MercuryCubeModel);
            _state.VenusCubeEffect.DrawIndexPrimitives(_state.VenusCubeModel);
            _state.EarthCubeEffect.DrawIndexPrimitives(_state.EarthCubeModel);
            _state.MarsCubeEffect.DrawIndexPrimitives(_state.MarsCubeModel);
            _state.MoonCubeEffect.DrawIndexPrimitives(_state.MoonCubeModel);
        }

        public void PerpareDrawer3D()
        {
            _game.GraphicsDevice.RasterizerState = RasterizerState.CullNone;
            _game.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
        }

        public void LoadTextures()
        {
            _texturesMap.LoadTextures();
        }
    }
}
