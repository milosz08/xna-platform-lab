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
            return Matrix.CreateRotationZ(MathHelper.ToRadians(controller.Arm2Pos.Z))
                * Matrix.CreateTranslation(Arm1Model.ARM_1_LENGTH, 0, 0)
                * Matrix.CreateRotationX(MathHelper.ToRadians(controller.Arm2Pos.X))
                * Matrix.CreateRotationY(MathHelper.ToRadians(controller.Arm1Pos.Y))
                * Matrix.CreateRotationZ(MathHelper.ToRadians(controller.Arm1Pos.Z));
        }
    }
}
