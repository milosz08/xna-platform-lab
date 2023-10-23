namespace XnaZal3
{
    public abstract class AbstractGame
    {
        protected GameWindow _game;
        protected GameState _state;

        public AbstractGame(GameWindow game, GameState state)
        {
            _game = game;
            _state = state;
        }
    }
}
