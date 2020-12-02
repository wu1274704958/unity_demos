using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class world_bg : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer sr;
    SpriteRenderer back_sr;
    Transform trans;
    Transform back_trans;

    public static Vector2 Size = new Vector2(8f,4.8f);
    public static Vector2 SIZE = new Vector2(800f, 480f);

    public float x_offset = 0f;
    public float w_rate = 2f;
    public GameObject back;

    public float speed = -0.01f;
    public float real_width = 0f;

    private void Awake()
    {
        real_width = UnityEngine.Screen.width / 100f;//aspect_ratio * Size.y;
    }

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        back_sr = back.GetComponent<SpriteRenderer>();

        trans = GetComponent<Transform>();
        back_trans = back.GetComponent<Transform>();

        float aspect_ratio = UnityEngine.Screen.width / UnityEngine.Screen.height;
        

        set_size(SIZE.x * w_rate, SIZE.y);
        set_size_bk(SIZE.x * w_rate, SIZE.y);

        x_offset = (real_width - sr.size.x) / 2f;

        set_x(-x_offset);
        set_bk_x(trans.position.x + get_gap());

        
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
        return sr.size.x - 0.001f;
    }
    void set_size(float w,float h)
    {
        sr.size = new Vector2(w / 100f , Size.y );
        float scale_y = h / 100f / Size.y;
        trans.localScale = new Vector3(1f, scale_y);
    }

    void set_size_bk(float w, float h)
    {
        back_sr.size = new Vector2(w / 100f, h / 100f);
        float scale_y = h / 100f / Size.y;
        back_trans.localScale = new Vector3(1f, scale_y);
    }

    // Update is called once per frame
    void Update()
    {
        check_swap();
        set_x(trans.position.x + speed * Time.deltaTime);
        set_bk_x(back_trans.position.x + speed * Time.deltaTime);
    }

    private void check_swap()
    {
        if(trans.position.x < -sr.size.x)
        {
            swap();
            set_bk_x(trans.position.x + get_gap());
        }
    }

    void swap()
    {
        SpriteRenderer sr_ = sr;
        Transform trans_ = trans;

        sr = back_sr;
        trans = back_trans;

        back_sr = sr_;
        back_trans = trans_;
    }
}
