using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class world_bg : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer sr;
    Transform trans;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        trans = GetComponent<Transform>();
        set_size(UnityEngine.Screen.width, UnityEngine.Screen.height);
    }

    void set_size(float w,float h)
    {
        sr.size = new Vector2(w / 100f , h/100f );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
