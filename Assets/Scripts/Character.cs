using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float sensitivity;
    public Rigidbody rb;
    public Vector3 targetPos;
    public Vector2 bounds;
 
    void Start()
    {
     
        InputPanel.Instance.OnDragDelta.AddListener(Drag);
        
       
        rb = transform.GetComponent<Rigidbody>();
        StartCoroutine("MoveRoutine");
     
    }


    public virtual Vector2 SetInput()
    {
        
        return Vector2.down;
    }
   public  virtual  IEnumerator MoveRoutine()
    {
        
         
        while (true)
        {
            targetPos += transform.forward * speed;
            rb.MovePosition(targetPos);
   
            yield return new WaitForFixedUpdate();
        }

    }

    public void Drag(Vector2 delta)   //PLAYER
    {
        print(delta.x);
        targetPos.x += delta.normalized.x * sensitivity;
        targetPos.x = Mathf.Clamp(targetPos.x, bounds.x, bounds.y);
        
        print("drag");
    }
  

  

   
}
