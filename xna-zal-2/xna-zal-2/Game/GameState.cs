using XnaZal2.Sprite;

namespace XnaZal2
{
    public class GameState
    {
        public PaddleSprite LeftPaddle { get; set; }
        public PaddleSprite RightPaddle { get; set; }
        public BallSprite BallSprite { get; set; }
        public FlameSprite FlameSprite { get; set; }
    }
}
