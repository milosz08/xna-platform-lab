using Microsoft.Xna.Framework.Graphics;

namespace XnaZal4
{
    public class GameCanvas : AbstractGame
    {
        public GameCanvas(GameWindow game, GameState state)
            : base(game, state)
        {
        }

        public void DrawAxisLines3D()
        {
            _state.AxisLines.Effect.DrawLinePrimitives(_state.AxisLines.Model.Vertices);
        }

        public void DrawRobotArms3D()
        {
            _state.Arm1.Effect.DrawTrianglePrimitives(_state.Arm1.Model);
            _state.Arm2.Effect.DrawTrianglePrimitives(_state.Arm2.Model);
            _state.GripLeft.Effect.DrawTrianglePrimitives(_state.GripLeft.Model);
            _state.GripRight.Effect.DrawTrianglePrimitives(_state.GripRight.Model);
            _state.Grip2Left.Effect.DrawTrianglePrimitives(_state.Grip2Left.Model);
            _state.Grip2Right.Effect.DrawTrianglePrimitives(_state.Grip2Right.Model);
        }

        public void PerpareDrawer3D()
        {
            _game.GraphicsDevice.RasterizerState = RasterizerState.CullNone;
            _game.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
        }
    }
}
