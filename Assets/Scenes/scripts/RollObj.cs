using UnityEngine;
using System.Collections;

namespace Assets.Scenes.scripts
{
    public class RollObj<Args,T,S> : MonoBehaviour where T : ICreater<Args, GameObject> where S:ISize,new() where Args:new()
    {
        private CachePool<GameObject,Args,T> pool;
        public Vector2 offset = Vector2.zero;
        public bool floor = true;
        private int repeat = 0;
        private S size;

        public RollObj()
        {
            size = new S();
            pool = new CachePool<GameObject, Args, T>();
        }

        // Use this for initialization
        void Start()
        {
            float x = 0;
            while(x < size.width())
            {
                GameObject g = pool.take(getArgs());
                g.transform.position = new Vector3(x, 0);
                PolygonCollider2D collider2D = g.GetComponent<PolygonCollider2D>();
                x += collider2D.bounds.size.x;
            }
        }

        virtual public Args getArgs()
        {
            return new Args();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}