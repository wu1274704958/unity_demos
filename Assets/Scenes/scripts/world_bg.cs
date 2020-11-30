﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class world_bg : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer sr;
    SpriteRenderer back_sr;
    Transform trans;
    Transform back_trans;

    public float w_rate = 2f;
    public GameObject back;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        back_sr = back.GetComponent<SpriteRenderer>();

        trans = GetComponent<Transform>();
        back_trans = back.GetComponent<Transform>();

        set_size(UnityEngine.Screen.width * w_rate, UnityEngine.Screen.height);
        set_x(UnityEngine.Screen.width / 100f / 2f);
        set_bk_x(trans.position.x + get_gap());
        
        set_size_bk(UnityEngine.Screen.width * w_rate, UnityEngine.Screen.height);
    }

    void set_x(float x)
    {
        trans.position = new Vector3(x, 0f, 0f);
    }

    void set_bk_x(float x)
    {
        back_trans.position = new Vector3(x, 0f, 0f);
    }

    float get_gap()
    {
        return sr.size.x;
    }
    void set_size(float w,float h)
    {
        sr.size = new Vector2(w / 100f , h/100f );
    }

    void set_size_bk(float w, float h)
    {
        back_sr.size = new Vector2(w / 100f, h / 100f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}