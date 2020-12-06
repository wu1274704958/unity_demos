using UnityEngine;
using UnityEditor;

namespace Assets.Scenes.scripts
{
    public class CreateRockd : ICreater<int, GameObject>
    {
        private static string[] rock_types = 
            { "rock.png", "rockGrass.png", "rock.png","rockIce.png","rockSnow.png" };
        public void apply(GameObject ct, int t)
        {
            Sprite sprite = app.loadFormAB<Sprite>("plane_ab.ab", rock_types[t]);
            ct.GetComponent<SpriteRenderer>().sprite = sprite;
        }

        public GameObject create(int t)
        {
            GameObject rock = app.loadFormAB<GameObject>("plane_ab.ab", "rock.prefab");
            apply(rock, t);
            return rock;
        }

        public void destroy(GameObject ct)
        {
            Object.Destroy(ct);
        }
    }
}