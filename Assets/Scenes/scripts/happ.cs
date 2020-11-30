using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class happ : MonoBehaviour
{
    RectTransform trans;
    public float scale_v = 0f;
    public float scale_zl = 0.1f;
    public float scale_s = 0.1f;

    public float pressed_scale_zl = 0.09f;

    public delegate void Ready();
    public event Ready e_ready;

    bool pressed = false;
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<RectTransform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!pressed)
        {
            scale_v += scale_zl;
            float s = (Mathf.Sin(scale_v) * scale_s) + 1f;
            trans.localScale = new Vector3(s, s);
        }
    }

    public void PointerDown()
    {
        //print("down");
        pressed = true;
        float now_scale = trans.localScale.x;
        trans.localScale = new Vector3(now_scale - pressed_scale_zl, now_scale - pressed_scale_zl);
        
        
    }

    public void PointerUp()
    {
        print("up");
        pressed = false;
        float now_scale = trans.localScale.x;
        trans.localScale = new Vector3(now_scale + pressed_scale_zl, now_scale + pressed_scale_zl);

        //Utils.Delay(this,() =>
        {
            e_ready.Invoke();
        }//, 0.001f);
    }
}
