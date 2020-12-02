using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ready : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ready_obj;
    public GameObject pressedObj;
    public GameObject perfab_plane;
    public GameObject perfab_pressedObj;
    public GameObject perfab_explode;
    public GameObject bgObj;
    GameObject plane_;
    public Vector2 birth_pos;

    void Start()
    {
        if(ready_obj != null)
        {
            happ h = ready_obj.GetComponent<happ>();
            h.e_ready += ready_;
        }
        float real_width = bgObj.GetComponent<world_bg>().real_width;
        birth_pos = new Vector2(real_width / -4f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ready_()
    {
        print("ready_");

        GameObject toggle = GameObject.Instantiate(perfab_pressedObj, Vector3.zero, new Quaternion());
        pressedObj = toggle.transform.GetChild(0).gameObject;

        plane_ = GameObject.Instantiate(perfab_plane, new Vector3(birth_pos.x, birth_pos.y), new Quaternion());
        plane plane = plane_.GetComponent<plane>();
        plane.pressedObj = pressedObj;
        plane.readyObj = this.gameObject;
        plane.pf_explode = perfab_explode;
        gameObject.SetActive(false);
    }
}
