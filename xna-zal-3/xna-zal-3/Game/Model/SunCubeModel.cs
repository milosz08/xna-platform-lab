using Microsoft.Xna.Framework;

namespace XnaZal3.Model
{
    public class SunCubeModel : AbstractCubeModel
    {
        public SunCubeModel() : base(2.0f, 0.03f, 0.5f, new Color[8]
        {
            Color.Yellow,           // 2
            Color.DarkOrange,       // 3
            Color.DarkOrange,       // 4
            Color.Yellow,           // 1
            Color.DarkOrange,       // 5   
            Color.Yellow,           // 6
            Color.Yellow,           // 7
            Color.DarkOrange,       // 8
        })
        {
        }
    }
}
