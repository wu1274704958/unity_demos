using UnityEngine;
using System.Collections;

namespace Assets.Scenes.scripts
{
    public class RollObj<Args,T,S> : MonoBehaviour where T : ICreater<Args, GameObject> where S:ISize,new() where Args:new()
    {
        private CachePool<GameObject,Args,T> pool;
        public Vector2 offset = Vector2.zero;
        public bool floor = true;
        public float speed;

        private int repeat = 0;
        private S size;
        private float _y;
        private float y_filp = 1;


        public RollObj()
        {
            size = new S();
            pool = new CachePool<GameObject, Args, T>();
        }

        // Use this for initialization
        void Start()
        {
            calc_y();

            float x = 0;
            
            while(x < size.width())
            {
                GameObject g = pool.take(getArgs());
                
                PolygonCollider2D collider2D = g.GetComponent<PolygonCollider2D>();
                g.transform.position = new Vector3(x, _y + (collider2D.bounds.size.y * y_filp) / 2f);
                x += collider2D.bounds.size.x;
            }
        }

        public void calc_y()
        {
            y_filp = floor ? -1f : 1f;
            _y = y_filp * size.height() / 2f;
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