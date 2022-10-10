using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
         InputPanel.Instance.OnDragPosition.AddListener(Drag);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Drag(Vector2 pos)
    {
        transform.position = pos;
        print("drag");
    }
    
    
}
