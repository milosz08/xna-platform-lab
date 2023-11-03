using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaZal4.Model
{
    public abstract class AbstractCuboidModel
        : AbstractMeshModel<VertexPositionNormalTexture>
    {
        protected readonly float _length;
        protected readonly float _baseSize;

        protected AbstractCuboidModel(float length, float baseSize)
            : base(36)
        {
            _length = length;
            _baseSize = baseSize;
            InitMeshStructure();
        }

        protected override void InitMeshStructure()
        {
            Vector3[] frontFaces = new Vector3[36]
            {
                // przód
                new Vector3(-_baseSize, -_baseSize, 0),
                new Vector3(-_baseSize, _baseSize, 0),
                new Vector3(_baseSize, -_baseSize, 0),
                new Vector3(-_baseSize, _baseSize, 0),
                new Vector3(_baseSize, _baseSize, 0),
                new Vector3(_baseSize, -_baseSize, 0),
                // tył
                new Vector3(-_baseSize, -_baseSize, _length),
                new Vector3(-_baseSize, _baseSize, _length),
                new Vector3(_baseSize, -_baseSize, _length),
                new Vector3(-_baseSize, _baseSize, _length),
                new Vector3(_baseSize, _baseSize, _length),
                new Vector3(_baseSize, -_baseSize, _length),
                // lewo
                new Vector3(-_baseSize, -_baseSize, 0),
                new Vector3(-_baseSize, _baseSize, 0),
                new Vector3(-_baseSize, -_baseSize, _length),
                new Vector3(-_baseSize, _baseSize, 0),
                new Vector3(-_baseSize, _baseSize, _length),
                new Vector3(-_baseSize, -_baseSize, _length),
                // prawo
                new Vector3(_baseSize, -_baseSize, 0),
                new Vector3(_baseSize, _baseSize, 0),
                new Vector3(_baseSize, -_baseSize, _length),
                new Vector3(_baseSize, _baseSize, 0),
                new Vector3(_baseSize, _baseSize, _length),
                new Vector3(_baseSize, -_baseSize, _length),
                // góra
                new Vector3(-_baseSize, _baseSize, 0),
                new Vector3(-_baseSize, _baseSize, _length),
                new Vector3(_baseSize, _baseSize, 0),
                new Vector3(-_baseSize, _baseSize, _length),
                new Vector3(_baseSize, _baseSize, _length),
                new Vector3(_baseSize, _baseSize, 0),
                // dół
                new Vector3(-_baseSize, -_baseSize, 0),
                new Vector3(-_baseSize, -_baseSize, _length),
                new Vector3(_baseSize, -_baseSize, 0),
                new Vector3(-_baseSize, -_baseSize, _length),
                new Vector3(_baseSize, -_baseSize, _length),
                new Vector3(_baseSize, -_baseSize, 0)
            };

            Vector2[] texBaseCoords = new Vector2[36];
            int k = 0;
            int texMultiplier = (int)(_length / _baseSize);

            CopyValues(GetSideFacesCoors(), texBaseCoords, ref k);
            CopyValues(GetSideFacesCoors(texMultiplier), texBaseCoords, ref k);
            CopyValues(GetTopAndBottomFacesCoors(texMultiplier / 2), texBaseCoords, ref k);

            _vertices = new VertexPositionNormalTexture[36];
            for (int i = 0; i < frontFaces.Length; i++)
            {
                Vector3 normalized = Vector3.Normalize(frontFaces[i]);
                _vertices[i] = new VertexPositionNormalTexture(frontFaces[i], normalized, texBaseCoords[i]);
            }
        }

        private void CopyValues(Vector2[] source, Vector2[] dest, ref int k)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    dest[k++] = source[j];
                }
            }
        }

        private Vector2[] GetSideFacesCoors(float textureCount)
        {
            return new Vector2[6]
            {
                new Vector2(0, 1),
                new Vector2(0, 0),
                new Vector2(textureCount, 1),
                new Vector2(0, 0),
                new Vector2(textureCount, 0),
                new Vector2(textureCount, 1),
            };
        }

        private Vector2[] GetSideFacesCoors()
        {
            return GetSideFacesCoors(1);
        }

        private Vector2[] GetTopAndBottomFacesCoors(float textureCount)
        {
            return new Vector2[6]
            {
                new Vector2(0, textureCount),
                new Vector2(0, 0),
                new Vector2(1, textureCount),
                new Vector2(0, 0),
                new Vector2(1, 0),
                new Vector2(1, textureCount),
            };
        }

        public abstract Matrix GenerateWorldMatrix(GameController controller);
    }
}
