using UnityEngine;
using UnityEditor;

namespace Assets.Scenes.scripts
{
    public class Size : ISize
    {
        public float height()
        {
            return world_bg.Size.y;
        }

        public Vector2 size()
        {
            return new Vector2(width(), height());
        }

        public float width()
        {
            return 2.39f * 2f * (Screen.width * 1f / Screen.height) ;
        }
    }
}