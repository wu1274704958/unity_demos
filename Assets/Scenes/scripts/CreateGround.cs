using UnityEngine;
using UnityEditor;

namespace Assets.Scenes.scripts
{
    public class CreateGround : ICreater<int, GameObject>
    {
        public void apply(GameObject ct, int t)
        {
            
        }

        public GameObject create(int t)
        {
            //RuntimeAnimatorController ctrl = app.loadFormAB<GameObject>("plane_ab.ab", "");
        }

        public void destroy(GameObject ct)
        {
            Object.Destroy(ct);
        }
    }
}