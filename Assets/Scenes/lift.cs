using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lift : MonoBehaviour
{
    // Start is called before the first frame update
    private void Reset()
    {
        print("Reset....");
    }

    private void OnGUI()
    {
        print("on gui....");
    }

    void Start()
    {
        print("Strat....");
    }

    // Update is called once per frame
    void Update()
    {
        print("Update ....");
    }

    private void OnDestroy()
    {
        print("OnDestroy ....");
    }
}
