using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ready : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ready_obj;

    void Start()
    {
        if(ready_obj != null)
        {
            happ h = ready_obj.GetComponent<happ>();
            h.e_ready += ready_;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ready_()
    {
        print("ready_");
        gameObject.SetActive(false);
    }
}
