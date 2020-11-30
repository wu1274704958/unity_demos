using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate2 : MonoBehaviour
{
    // Start is called before the first frame update
    private RectTransform ts;
    void Start()
    {
        print("Strat ....");
        ts = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        ts.Rotate(Vector3.forward, 0.1f);
    }
}
