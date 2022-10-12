using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using  DG.Tweening;
public class Character : MonoBehaviour,IHandGrow
{
    // Start is called before the first frame update
   
    public float sensitivity;
    public Rigidbody rb;
    public Vector3 targetPos;
    public Vector2 bounds;
    public Wall wall;
    void Start()
    {
     
        InputPanel.Instance.OnDragDelta.AddListener(Drag);
        
        rb = transform.GetComponent<Rigidbody>();
       
     
    }
    public void ChangeHandScale()
    {
        GameManager.Instance.leftHand.DOScale(GameManager.Instance.handScaleRate, 0.25f).SetRelative().SetEase(Ease.Linear);
        GameManager.Instance.rightHand.DOScale(GameManager.Instance.handScaleRate, 0.25f).SetRelative().SetEase(Ease.Linear);
    }

   public void SpeedUp()
    {
        GameManager.Instance.speed += GameManager.Instance.speedRate;
    }

 
   public  virtual  IEnumerator MoveRoutine()
    {
        
         
        while (true)
        {
            targetPos += transform.forward * GameManager.Instance.speed*Time.fixedDeltaTime;
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



    public void DestructWall()
    {
        Rigidbody[] rigidbodies=  wall.transform.GetComponentsInChildren<Rigidbody>();
          print(rigidbodies.Length);
        for (int i = 0; i < rigidbodies.Length; i++)
        {
            print("calis");
           
            rigidbodies[i].AddExplosionForce(220,rigidbodies[i].position,3f,3f,ForceMode.Impulse);
            Destroy(rigidbodies[i].gameObject,5f);
        }
    }
 
}
