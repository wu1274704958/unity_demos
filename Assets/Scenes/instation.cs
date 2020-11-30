using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instation : MonoBehaviour 
{
    public GameObject obj;
    public GameObject oth_canvas;
    private GameObject self;

    // Start is called before the first frame update
    void Start()
    {
        self = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
       
        if(self.activeSelf)
        {
            if (oth_canvas == null)
            {
                oth_canvas = (GameObject)Instantiate(obj, Vector3.zero, new Quaternion());
                GameObject img = getChildByName(oth_canvas, "img");
                if(img != null)
                {
                    instation i = img.GetComponent<instation>();
                    if (i != null) i.oth_canvas = self;
                }
            }
            else
                oth_canvas.SetActive(true);
            self.SetActive(false);

        }
        else
        {
            oth_canvas.SetActive(false);
            self.SetActive(true);
        }


    }

    public GameObject getChildByName(GameObject obj,string name)
    {
        for(int i = 0;i < obj.transform.childCount;++i)
        {
            if(obj.transform.GetChild(i).name.Equals(name))
            {
                return obj.transform.GetChild(i).gameObject;
            }
        }
        return null;   
    }
}
