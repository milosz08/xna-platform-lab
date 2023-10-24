using XnaZal3.Model;

namespace XnaZal3
{
    public class GameState
    {
        public bool HideMesh { get; set; }
        public bool EmptyBackground { get; set; }

        public ModelEffectBinder<GridMeshModel> _gridMeshModel;
        public ModelEffectBinder<SunCubeModel> _sunCubeModel;
        public ModelEffectBinder<MercuryCubeModel> _mercuryCubeModel;
        public ModelEffectBinder<VenusCubeModel> _venusCubeModel;
        public ModelEffectBinder<EarthCubeModel> _earthCubeModel;
        public ModelEffectBinder<MoonCubeModel> _moonCubeModel;
        public ModelEffectBinder<MarsCubeModel> _marsCubeModel;

        public GameState(GameWindow game)
        {
            _gridMeshModel = new ModelEffectBinder<GridMeshModel>(new GridMeshModel(), game);
            _sunCubeModel = new ModelEffectBinder<SunCubeModel>(new SunCubeModel(), game);
            _sunCubeModel = new ModelEffectBinder<SunCubeModel>(new SunCubeModel(), game);
            _mercuryCubeModel = new ModelEffectBinder<MercuryCubeModel>(new MercuryCubeModel(), game);
            _venusCubeModel = new ModelEffectBinder<VenusCubeModel>(new VenusCubeModel(), game);
            _earthCubeModel = new ModelEffectBinder<EarthCubeModel>(new EarthCubeModel(), game);
            _moonCubeModel = new ModelEffectBinder<MoonCubeModel>(new MoonCubeModel(), game);
            _marsCubeModel = new ModelEffectBinder<MarsCubeModel>(new MarsCubeModel(), game);
        }

        public ModelEffectBinder<GridMeshModel> GridMesh
        {
            get => _gridMeshModel;
        }

        public ModelEffectBinder<SunCubeModel> SunCube
        {
            get => _sunCubeModel;
        }

        public ModelEffectBinder<MercuryCubeModel> MercuryCube
        {
            get => _mercuryCubeModel;
        }

        public ModelEffectBinder<VenusCubeModel> VenusCube
        {
            get => _venusCubeModel;
        }

        public ModelEffectBinder<EarthCubeModel> EarthCube
        {
            get => _earthCubeModel;
        }

        public ModelEffectBinder<MoonCubeModel> MoonCube
        {
            get => _moonCubeModel;
        }

        public ModelEffectBinder<MarsCubeModel> MarsCube
        {
            get => _marsCubeModel;
        }
    }
}
