using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using  DG.Tweening;
using PunchRunner.GameElements;
using PunchRunner.Interfaces;
using PunchRunner.Managers;

public class Character : MonoBehaviour,IHandGrow
{
    // Start is called before the first frame update
   
 
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
        
        targetPos.x += delta.normalized.x * GameManager.Instance.sensitivity;
        targetPos.x = Mathf.Clamp(targetPos.x, bounds.x, bounds.y);
       
       
    }

    public void DestructWall()
    {
        GameManager.Instance.PlayAudio(GameManager.Instance.punchClip);
        Rigidbody[] rigidbodies=  wall.transform.GetComponentsInChildren<Rigidbody>();
        
        for (int i = 0; i < rigidbodies.Length; i++)
        {
           
            rigidbodies[i].AddExplosionForce(220,rigidbodies[i].position,3f,3f,ForceMode.Impulse);
            Destroy(rigidbodies[i].gameObject,5f);
        }
    }
 
}
