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
    public int type = 0;
    private static string[] plane_types = { "planeBlue1.controller", "planeRed1.controller", "planeYellow1.controller" };

    private GameObject toggle;
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
        
        toggle = GameObject.Instantiate(perfab_pressedObj, Vector3.zero, new Quaternion());

        pressedObj = toggle.transform.GetChild(0).gameObject;

        toggle.SetActive(true);

        plane_ = GameObject.Instantiate(perfab_plane, new Vector3(birth_pos.x, birth_pos.y), new Quaternion());
        plane p = plane_.GetComponent<plane>();
        p.pressedObj = pressedObj;
        p.readyObj = this.gameObject;
        p.pf_explode = perfab_explode;
        p.e_dead += dead;
        gameObject.SetActive(false);


        RuntimeAnimatorController ctrl = app.loadFormAB<RuntimeAnimatorController>("plane_ab.ab", plane_types[type]);
        plane_.GetComponent<Animator>().runtimeAnimatorController = ctrl;
    }

    private void reset_()
    {
        Destroy(toggle.gameObject);
        gameObject.SetActive(true);
        type += 1;
        if (type >= 3) type = 0;
    }

    void dead()
    {
        reset_();
    }
}
