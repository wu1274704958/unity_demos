using UnityEngine;
using System.Collections;
using System;

namespace Assets.Scenes.scripts
{
    public abstract class RollObj<Args,T,S> : MonoBehaviour where T : ICreater<Args, GameObject>,new() where S:ISize,new() where Args:new()
    {
        
        public Vector2 offset = new Vector2(1f,1f);
        public bool floor = true;
        public float speed;

        protected CachePool<GameObject, Args, T> pool;
        public int repeat = 0;
        public S size;
        public float _y;
        public float y_filp = 1;
        public float bx;
        public int min_count = 1;
        public ArrayList list;
        public float rand_min = 0f,rand_max = 0f;
        public bool random = false;


        public RollObj()
        {
            list = new ArrayList();
            size = new S();
            pool = new CachePool<GameObject, Args, T>();
        }

        // Use this for initialization
        virtual public void Start()
        {
            calc_y();

            GameObject last = pool.take(getArgs());
            float x = -size.width() / 2f;
            last = Instantiate(last);

            x += bx;
            do
            {
                GameObject g = pool.take(getArgs());
                g = Instantiate(g);
                print("instance......... " + x +" " + (_y + offset.y));
                g.transform.position = new Vector3(x, _y + offset.y);
                x += offset.x;
                list.Add(g);
                
            } 
            while (x < size.width() / 2f || list.Count < min_count);
            apply_last(last);
            repeat = list.Count;
        }

        virtual protected void apply_last(GameObject last_)
        {
            float r = 0f;
            if(random)
            {
                r = UnityEngine.Random.Range(rand_min, rand_max);            
            }
            last_.transform.position = new Vector3(last().transform.position.x + offset.x + r
                , last().transform.position.y);
            list.Add(last_);
        }

        protected GameObject last()
        {
            return list[list.Count - 1] as GameObject;
        }

        public void calc_y()
        {
            y_filp = floor ? -1f : 1f;
            _y = y_filp * size.height() / 2f;
        }

        abstract public Args getArgs();

        virtual public bool need_refresh()
        {
            return false;
        }

        // Update is called once per frame
        virtual public void Update()
        {
            for(int i = 0;i < list.Count;++i)
            {
                (list[i] as GameObject).transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
            }
            GameObject g = list[0] as GameObject;
            if(g.transform.position.x < (-size.width() / 2f + (-offset.x / 2f)))
            {
                list.RemoveAt(0);
                if(need_refresh())
                {
                    pool.apply(g, getArgs());
                }
                apply_last(g);
            }
        }
    }
}