using Microsoft.Xna.Framework;

namespace XnaZal4.Model
{
    public class GripModel : AbstractCuboidModel
    {
        public static readonly float GRIP_LENGTH = 0.8f;

        private readonly int _multipier;

        public GripModel(int multipier)
            : base(GRIP_LENGTH, 0.05f)
        {
            _multipier = multipier;
        }

        public GripModel()
            : this(1)
        {
        }

        public override Matrix GenerateWorldMatrix(GameController controller)
        {
            return Matrix.CreateRotationY(MathHelper.ToRadians(controller.GripPos.Y * _multipier))
                * Matrix.CreateTranslation(Arm2Model.ARM_2_LENGTH, 0, 0)
                * Matrix.CreateRotationZ(MathHelper.ToRadians(controller.Arm2Pos.Z))
                * Matrix.CreateRotationX(MathHelper.ToRadians(controller.Arm2Pos.X))
                * Matrix.CreateTranslation(Arm1Model.ARM_1_LENGTH, 0, 0)
                * Matrix.CreateRotationY(MathHelper.ToRadians(controller.Arm1Pos.Y))
                * Matrix.CreateRotationZ(MathHelper.ToRadians(controller.Arm1Pos.Z));
        }
    }
}
