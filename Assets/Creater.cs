using UnityEngine;
using System.Collections;

namespace Assets
{
    public interface ICreater<T,CT> where CT : class
    {
        CT create(T t);
        void apply(CT ct,T t);
        void destroy(CT ct);
    }
}