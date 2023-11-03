using Microsoft.Xna.Framework;

namespace XnaZal4.Model
{
    public class Grip2Model : AbstractCuboidModel
    {
        public static readonly float GRIP_2_LENGTH = 0.5f;

        private readonly int _multipier;

        public Grip2Model(int multipier)
            : base(GRIP_2_LENGTH, 0.03f)
        {
            _multipier = multipier;
        }

        public Grip2Model()
            : this(1)
        {
        }

        public override Matrix GenerateWorldMatrix(GameController controller)
        {
            return Matrix.CreateRotationY(MathHelper.ToRadians(controller.Grip2Pos.Y * _multipier))
                * Matrix.CreateTranslation(0, 0, GripModel.GRIP_1_LENGTH)
                * Matrix.CreateRotationY(MathHelper.ToRadians(controller.GripPos.Y))
                * Matrix.CreateTranslation(0, 0, Arm2Model.ARM_2_LENGTH)
                * Matrix.CreateRotationZ(MathHelper.ToRadians(controller.Arm2Pos.Z))
                * Matrix.CreateRotationX(MathHelper.ToRadians(controller.Arm2Pos.X))
                * Matrix.CreateTranslation(0, 0, Arm1Model.ARM_1_LENGTH)
                * Matrix.CreateRotationX(MathHelper.ToRadians(controller.Arm1Pos.X))
                * Matrix.CreateRotationY(MathHelper.ToRadians(controller.Arm1Pos.Y));
        }
    }
}
