namespace XnaZal4
{
    public abstract class AbstractGame
    {
        protected GameWindow _game;
        protected GameState _state;

        protected AbstractGame(GameWindow game, GameState state)
        {
            _game = game;
            _state = state;
        }
    }
}
