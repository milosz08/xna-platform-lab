using XnaZal3.Model;

namespace XnaZal3
{
    public class GameState
    {
        public bool HideMesh { get; set; }
        public bool EmptyBackground { get; set; }

        private readonly ModelEffectBinder<GridMeshModel> _gridMesh;
        private readonly ModelEffectBinder<SunCubeModel> _sunCube;
        private readonly ModelEffectBinder<MercuryCubeModel> _mercuryCube;
        private readonly ModelEffectBinder<VenusCubeModel> _venusCube;
        private readonly ModelEffectBinder<EarthCubeModel> _earthCube;
        private readonly ModelEffectBinder<MoonCubeModel> _moonCube;
        private readonly ModelEffectBinder<MarsCubeModel> _marsCube;

        public GameState(GameWindow game)
        {
            _gridMesh = new ModelEffectBinder<GridMeshModel>(new GridMeshModel(), game);
            _sunCube = new ModelEffectBinder<SunCubeModel>(new SunCubeModel(), game);
            _sunCube = new ModelEffectBinder<SunCubeModel>(new SunCubeModel(), game);
            _mercuryCube = new ModelEffectBinder<MercuryCubeModel>(new MercuryCubeModel(), game);
            _venusCube = new ModelEffectBinder<VenusCubeModel>(new VenusCubeModel(), game);
            _earthCube = new ModelEffectBinder<EarthCubeModel>(new EarthCubeModel(), game);
            _moonCube = new ModelEffectBinder<MoonCubeModel>(new MoonCubeModel(), game);
            _marsCube = new ModelEffectBinder<MarsCubeModel>(new MarsCubeModel(), game);
        }

        public ModelEffectBinder<GridMeshModel> GridMesh
        {
            get => _gridMesh;
        }

        public ModelEffectBinder<SunCubeModel> SunCube
        {
            get => _sunCube;
        }

        public ModelEffectBinder<MercuryCubeModel> MercuryCube
        {
            get => _mercuryCube;
        }

        public ModelEffectBinder<VenusCubeModel> VenusCube
        {
            get => _venusCube;
        }

        public ModelEffectBinder<EarthCubeModel> EarthCube
        {
            get => _earthCube;
        }

        public ModelEffectBinder<MoonCubeModel> MoonCube
        {
            get => _moonCube;
        }

        public ModelEffectBinder<MarsCubeModel> MarsCube
        {
            get => _marsCube;
        }
    }
}
