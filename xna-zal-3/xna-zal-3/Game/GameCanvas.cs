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
                _game.GraphicsDevice.Clear(Color.Black);
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
                _state.GridMesh.Effect.DrawPrimitives(_state.GridMesh.Model.Vertices);
            }
        }

        public void DrawPlanets3D()
        {
            _state.SunCube.Effect.DrawIndexPrimitives(_state.SunCube.Model);
            _state.MercuryCube.Effect.DrawIndexPrimitives(_state.MercuryCube.Model);
            _state.VenusCube.Effect.DrawIndexPrimitives(_state.VenusCube.Model);
            _state.EarthCube.Effect.DrawIndexPrimitives(_state.EarthCube.Model);
            _state.MoonCube.Effect.DrawIndexPrimitives(_state.MoonCube.Model);
            _state.MarsCube.Effect.DrawIndexPrimitives(_state.MarsCube.Model);
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
