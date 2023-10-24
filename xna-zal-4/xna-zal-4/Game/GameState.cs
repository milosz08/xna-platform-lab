using XnaZal4.Model;

namespace XnaZal4
{
    public class GameState
    {
        private readonly ModelEffectBinder<AxisLinesModel> _axisLines;
        private readonly ModelEffectBinder<Arm1Model> _arm1;
        private readonly ModelEffectBinder<Arm2Model> _arm2;
        private readonly ModelEffectBinder<GripModel> _gripLeft;
        private readonly ModelEffectBinder<GripModel> _gripRight;

        public GameState(GameWindow game)
        {
            _axisLines = new ModelEffectBinder<AxisLinesModel>(new AxisLinesModel(), game);
            _arm1 = new ModelEffectBinder<Arm1Model>(new Arm1Model(), game, "metal1");
            _arm2 = new ModelEffectBinder<Arm2Model>(new Arm2Model(), game, "metal2");
            _gripLeft = new ModelEffectBinder<GripModel>(new GripModel(), game, "metal3");
            _gripRight = new ModelEffectBinder<GripModel>(new GripModel(-1), game, "metal3");
        }

        public ModelEffectBinder<AxisLinesModel> AxisLines
        {
            get => _axisLines;
        }

        public ModelEffectBinder<Arm1Model> Arm1
        {
            get => _arm1;
        }

        public ModelEffectBinder<Arm2Model> Arm2
        {
            get => _arm2;
        }

        public ModelEffectBinder<GripModel> GripLeft
        {
            get => _gripLeft;
        }

        public ModelEffectBinder<GripModel> GripRight
        {
            get => _gripRight;
        }
    }
}
