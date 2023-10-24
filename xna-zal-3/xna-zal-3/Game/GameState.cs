using XnaZal3.Model;

namespace XnaZal3
{
    public class GameState
    {
        public bool HideMesh { get; set; }
        public bool EmptyBackground { get; set; }

        public GridMeshModel GridMeshModel { get; set; }
        public SunCubeModel SunCubeModel { get; set; }
        public MercuryCubeModel MercuryCubeModel { get; set; }
        public VenusCubeModel VenusCubeModel { get; set; }
        public EarthCubeModel EarthCubeModel { get; set; }
        public MarsCubeModel MarsCubeModel { get; set; }
        public MoonCubeModel MoonCubeModel { get; set; }

        private GameSimpleEffect
            _meshEffect,
            _sunCubeEffect,
            _mercuryCubeEffect,
            _venusCubeEffect,
            _earthCubeEffect,
            _marsCubeEffect,
            _moonCubeEffect;

        public GameState(GameWindow game)
        {
            SunCubeModel = new SunCubeModel();
            GridMeshModel = new GridMeshModel();
            MercuryCubeModel = new MercuryCubeModel();
            VenusCubeModel = new VenusCubeModel();
            EarthCubeModel = new EarthCubeModel();
            MarsCubeModel = new MarsCubeModel();
            MoonCubeModel = new MoonCubeModel();

            _meshEffect = new GameSimpleEffect(game.GraphicsDevice);
            _sunCubeEffect = new GameSimpleEffect(game.GraphicsDevice);
            _mercuryCubeEffect = new GameSimpleEffect(game.GraphicsDevice);
            _venusCubeEffect = new GameSimpleEffect(game.GraphicsDevice);
            _earthCubeEffect = new GameSimpleEffect(game.GraphicsDevice);
            _marsCubeEffect = new GameSimpleEffect(game.GraphicsDevice);
            _moonCubeEffect = new GameSimpleEffect(game.GraphicsDevice);
        }

        public GameSimpleEffect MeshEffect
        {
            get => _meshEffect;
        }

        public GameSimpleEffect SunCubeEffect
        {
            get => _sunCubeEffect;
        }

        public GameSimpleEffect MercuryCubeEffect
        {
            get => _mercuryCubeEffect;
        }

        public GameSimpleEffect VenusCubeEffect
        {
            get => _venusCubeEffect;
        }

        public GameSimpleEffect EarthCubeEffect
        {
            get => _earthCubeEffect;
        }

        public GameSimpleEffect MarsCubeEffect
        {
            get => _marsCubeEffect;
        }

        public GameSimpleEffect MoonCubeEffect
        {
            get => _moonCubeEffect;
        }
    }
}
