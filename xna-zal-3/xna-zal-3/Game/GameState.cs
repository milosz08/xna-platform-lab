using XnaZal3.Model;

namespace XnaZal3
{
    public class GameState
    {
        public bool HideMesh { get; set; }
        public bool EmptyBackground { get; set; }

        public GridMeshModel GridMeshModel { get; set; }
        public SunCubeModel SunCubeModel { get; set; }

        private GameSimpleEffect
            _meshEffect,
            _sunCubeEffect;

        public GameState(GameWindow game)
        {
            SunCubeModel = new SunCubeModel();
            GridMeshModel = new GridMeshModel();
            _meshEffect = new GameSimpleEffect(game.GraphicsDevice);
            _sunCubeEffect = new GameSimpleEffect(game.GraphicsDevice);
        }

        public GameSimpleEffect MeshEffect
        {
            get => _meshEffect;
        }

        public GameSimpleEffect SunCubeEffect
        {
            get => _sunCubeEffect;
        }
    }
}
