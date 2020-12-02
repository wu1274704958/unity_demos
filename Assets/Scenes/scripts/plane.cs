using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plane : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D body2D;
    public float rotate_speed = 160f;
    public GameObject pressedObj;
    public GameObject readyObj;
    public Vector2 froce;
    public GameObject pf_explode;

    public delegate void Dead();
    public event Dead e_dead;
    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
        tigger tigger_ = pressedObj.GetComponent<tigger>();
        if(tigger_)
        {
            tigger_.e_pressed += down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void FixedUpdate()
    {
        if (this.body2D.bodyType == RigidbodyType2D.Dynamic)
        {
            var deltaTime = Time.fixedDeltaTime * rotate_speed;
            var v2 = this.body2D.velocity;
            // s = (v0 + v1) * t / 2
            this.body2D.MoveRotation(deltaTime * v2.y);
        }
    }
    
    public void down()
    {
        body2D.AddForce(froce);
        GameObject explode = GameObject.Instantiate(pf_explode);
    }

    public void dead()
    {

    }
}
