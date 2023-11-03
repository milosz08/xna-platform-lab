using Microsoft.Xna.Framework;

namespace XnaZal4.Model
{
    public class Arm2Model : AbstractCuboidModel
    {
        public static readonly float ARM_2_LENGTH = 2f;

        public Arm2Model()
            : base(ARM_2_LENGTH, 0.10f)
        {
        }

        public override Matrix GenerateWorldMatrix(GameController controller)
        {
            return Matrix.CreateRotationX(MathHelper.ToRadians(controller.Arm2Pos.X))
                * Matrix.CreateTranslation(0, 0, Arm1Model.ARM_1_LENGTH)
                * Matrix.CreateRotationZ(MathHelper.ToRadians(controller.Arm2Pos.Z))
                * Matrix.CreateRotationX(MathHelper.ToRadians(controller.Arm1Pos.X))
                * Matrix.CreateRotationY(MathHelper.ToRadians(controller.Arm1Pos.Y));
        }
    }
}
