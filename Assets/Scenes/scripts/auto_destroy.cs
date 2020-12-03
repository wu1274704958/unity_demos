using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auto_destroy : MonoBehaviour
{
    public float second = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Utils.Delay(this, destroy, second);
    }

    private void destroy()
    {
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
