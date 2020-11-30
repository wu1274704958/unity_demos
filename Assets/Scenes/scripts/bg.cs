using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 parent_size_rate = Vector2.one;
    
    void Start()
    {
        RectTransform trans = GetComponent<RectTransform>();
        RectTransform parent = trans.parent.GetComponent<RectTransform>();
        float width = parent.rect.width * parent_size_rate.x;
        float height = parent.rect.height * parent_size_rate.y;

        trans.sizeDelta = new Vector2(width, height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
