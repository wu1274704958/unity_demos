using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tigger : MonoBehaviour
{
    // Start is called before the first frame update

    public delegate void Pressed();
    public event Pressed e_pressed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Down()
    {
        e_pressed.Invoke();
    }
}
