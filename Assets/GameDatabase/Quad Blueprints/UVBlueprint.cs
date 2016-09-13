using UnityEngine;
namespace ProjectSpacer
{
    public class UVBlueprint
    {
        Vector2Int _uv;
        public Vector2Int UV
        {
            get { return _uv; }
            protected set { _uv = value; }
        }

        bool _colorable;
        public bool Colorable
        {
            get { return _colorable; }
            protected set { _colorable = value; }
        }

        bool _flipAcrossX;
        public bool FlipAcrossX
        {
            get { return _flipAcrossX; }
            protected set { _flipAcrossX = value; }
        }

        public UVBlueprint(Vector2Int newUV, bool colorable, bool flipAcrossX)
        {
            UV = newUV;
            Colorable = colorable;
            FlipAcrossX = flipAcrossX;
        }

    }
}