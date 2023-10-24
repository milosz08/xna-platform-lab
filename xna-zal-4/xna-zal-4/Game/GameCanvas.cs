using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaZal4
{
    public class GameCanvas : AbstractGame
    {
        public GameCanvas(GameWindow game, GameState state)
            : base(game, state)
        {
        }

        public void DrawBackground()
        {
            _game.GraphicsDevice.Clear(Color.PaleTurquoise);
        }

        public void DrawAxisLines3D()
        {
            _state.AxisLines.Effect.DrawPrimitives(_state.AxisLines.Model.Vertices);
        }

        public void DrawRobotArms3D()
        {
            _state.Arm1.Effect.DrawIndexPrimitives(_state.Arm1.Model);
            _state.Arm2.Effect.DrawIndexPrimitives(_state.Arm2.Model);
            _state.GripLeft.Effect.DrawIndexPrimitives(_state.GripLeft.Model);
            _state.GripRight.Effect.DrawIndexPrimitives(_state.GripRight.Model);
        }

        public void PerpareDrawer3D()
        {
            _game.GraphicsDevice.RasterizerState = RasterizerState.CullNone;
            _game.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
        }
    }
}
