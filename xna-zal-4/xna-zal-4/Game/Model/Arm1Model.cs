using Microsoft.Xna.Framework;

namespace XnaZal4.Model
{
    public class Arm1Model : AbstractCuboidModel
    {
        public static readonly float ARM_1_LENGTH = 2.2f;

        public Arm1Model()
            : base(ARM_1_LENGTH, 0.15f)
        {
        }

        public override Matrix GenerateWorldMatrix(GameController controller)
        {
            return Matrix.CreateRotationX(MathHelper.ToRadians(controller.Arm1Pos.Z))
                * Matrix.CreateRotationY(MathHelper.ToRadians(controller.Arm1Pos.Y));
        }
    }
}
