using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hsppy_rotate : MonoBehaviour
{
    RectTransform trans;
    public float rotate_v = 0f;
    public float rotate_zl = 0.1f;
    public float rotate_s = 10f;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
       
        {
            rotate_v += rotate_zl * Time.deltaTime;
            float s = (Mathf.Sin(rotate_v) * rotate_s) + 1f;
            trans.localRotation = Quaternion.Euler(0f,0f,s);
        }
    }
}
