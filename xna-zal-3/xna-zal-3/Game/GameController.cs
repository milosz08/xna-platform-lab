using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using XnaZal3.Model;

namespace XnaZal3
{
    public class GameController : AbstractGame
    {
        private static readonly float ANGLE_ROTATION_SPEED = 0.02f;                 // szybkość poruszania siatki
        private static readonly Vector3 INIT_CAMERA_ANGLE = new(0.2f, -0.2f, 4f);   // początkowy kąt kamery
        private static readonly float BOTTOM_TOLERANCE = 0.1f;                      // blokada zmniejszania siatki
        private static readonly float TOP_TOLERANCE = 15f;                          // blokada zwiększania siatki

        private bool _isXpressed, _isBpressed;

        private float _angleX = INIT_CAMERA_ANGLE.X;
        private float _angleY = INIT_CAMERA_ANGLE.Y;
        private float _angleZ = INIT_CAMERA_ANGLE.Z;

        Matrix viewMatrix, projection;

        public GameController(GameWindow game, GameState state)
            : base(game, state)
        {
        }

        public void Interact()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            ChangeDrawingBackgroundAndMesh(keyboardState);
            ChangeGridMeshAngle(keyboardState);

            viewMatrix = Matrix.CreateLookAt(new Vector3(_angleZ * 0.1f, _angleZ * 1.0f, _angleZ * 6.0f), Vector3.Zero, Vector3.Up);
            viewMatrix = Matrix.CreateRotationX(_angleX) * Matrix.CreateRotationY(_angleY) * viewMatrix;
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(50), _game.GraphicsDevice.Viewport.AspectRatio, 0.1f, 1000.0f);

            TransformCubeObject(_state.SunCubeEffect, _state.SunCubeModel);
            TransformCubeObject(_state.MercuryCubeEffect, _state.MercuryCubeModel);
            TransformCubeObject(_state.VenusCubeEffect, _state.VenusCubeModel);
            TransformCubeObject(_state.EarthCubeEffect, _state.EarthCubeModel);

            _state.MoonCubeModel.SetEarhPos(_state.EarthCubeModel.CurrentPos);

            TransformCubeObject(_state.MarsCubeEffect, _state.MarsCubeModel);
            TransformCubeObject(_state.MoonCubeEffect, _state.MoonCubeModel);

            _state.MeshEffect.View = viewMatrix;
            _state.MeshEffect.Projection = projection;           
        }

        private void TransformCubeObject(GameSimpleEffect effect, AbstractCubeModel model)
        {
            effect.View = viewMatrix;
            effect.Projection = model.GetProjectionMatrix(_game);

            effect.World = (model.RotatingState *= Matrix.CreateRotationY(_state.VenusCubeModel.RotationSpeed))
                * model.XDeviationMatrix * model.IncreaseAroundState();
        }

        private void ChangeGridMeshAngle(KeyboardState keyboardState)
        {
            if (_angleZ >= BOTTOM_TOLERANCE)
            {
                if (keyboardState.IsKeyDown(Keys.A))
                {
                    _angleZ -= ANGLE_ROTATION_SPEED;
                }
            }
            if (_angleZ <= TOP_TOLERANCE)
            {
                if (keyboardState.IsKeyDown(Keys.Q))
                {
                    _angleZ += ANGLE_ROTATION_SPEED;
                }
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                _angleY += ANGLE_ROTATION_SPEED;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                _angleY -= ANGLE_ROTATION_SPEED;
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                _angleX += ANGLE_ROTATION_SPEED;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                _angleX -= ANGLE_ROTATION_SPEED;
            }
        }

        private void ChangeDrawingBackgroundAndMesh(KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyDown(Keys.X)) // siatka
            {
                if (!_isXpressed)
                {
                    _state.HideMesh = !_state.HideMesh;
                    _isXpressed = true;
                }
            }
            if (keyboardState.IsKeyDown(Keys.B)) // tło
            {
                if (!_isBpressed)
                {
                    _state.EmptyBackground = !_state.EmptyBackground;
                    _isBpressed = true;
                }
            }
            if (keyboardState.IsKeyUp(Keys.X))
            {
                _isXpressed = false;
            }
            if (keyboardState.IsKeyUp(Keys.B))
            {
                _isBpressed = false;
            }
        }

        public void ExitOnEsc()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                _game.Exit();
            }
        }
    }
}
