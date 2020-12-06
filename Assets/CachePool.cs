using UnityEngine;
using System.Collections;

namespace Assets
{
    public class CachePool<Rt,Args,T> where Rt:class where T:ICreater<Args,Rt> ,new()
    {
        private ArrayList active;
        private ArrayList rest;
        private T creater;

        public CachePool()
        {
            creater = new T();
            active = new ArrayList();
            rest = new ArrayList();
        }

        public Rt take(Args a)
        {
            if(rest.Count > 0)
            {
                Rt rt = rest[rest.Count - 1] as Rt;
                rest.RemoveAt(rest.Count - 1);
                creater.apply(rt, a);
                active.Add(rt);
                return rt;
            }
            else
            {
                Rt rt = creater.create(a);
                active.Add(rt);
                return rt;
            }
        }

        public void back(Rt r)
        {
            int idx = active.IndexOf(r);
            if(idx >= 0)
            {
                active.RemoveAt(idx);
                rest.Add(r);
            }
        }

        public void apply(Rt r,Args a)
        {
            creater.apply(r, a);
        }
    }
}