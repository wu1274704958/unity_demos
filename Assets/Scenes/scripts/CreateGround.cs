using UnityEngine;
using UnityEditor;

namespace Assets.Scenes.scripts
{
    public class CreateGround : ICreater<int, GameObject>
    {
        private static string[] ground_types = 
            { "groundDirt.png", "groundGrass.png", "groundRock.png","groundIce.png","groundSnow.png" };
        public void apply(GameObject ct, int t)
        {
            Sprite sprite = app.loadFormAB<Sprite>("plane_ab.ab", ground_types[t]);
            ct.GetComponent<SpriteRenderer>().sprite = sprite;
        }

        public GameObject create(int t)
        {
            GameObject ground = app.loadFormAB<GameObject>("plane_ab.ab", "groundDirt.prefab");
            apply(ground, t);
            return ground;
        }

        public void destroy(GameObject ct)
        {
            Object.Destroy(ct);
        }
    }
}