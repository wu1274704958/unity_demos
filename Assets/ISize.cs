using UnityEngine;
using System.Collections;

namespace Assets
{
    public interface ISize
    {
        Vector2 size();
        float width();
        float height();
    }
}