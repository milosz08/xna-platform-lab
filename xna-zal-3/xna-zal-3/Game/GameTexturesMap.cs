using Microsoft.Xna.Framework.Graphics;

namespace XnaZal3
{
    public class GameTexturesMap : AbstractGame
    {
        private Texture2D _background;

        public GameTexturesMap(GameWindow game, GameState state)
            : base(game, state)
        {
        }

        public void LoadTextures()
        {
            _background = LoadTexture("stars");
        }

        private Texture2D LoadTexture(string assetName)
        {
            return _game.Content.Load<Texture2D>(string.Format(@"{0}", assetName));
        }

        public Texture2D Background
        {
            get => _background;
        }
    }
}
