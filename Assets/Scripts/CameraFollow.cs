using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 _offset;

    [SerializeField] private float camFollowSpeed;
    // Start is called before the first frame update

    private void Start()
    {
        _offset = GameManager.Instance.character.transform.position - transform.position;
    }

    public IEnumerator FollowRoutine()
    { 
        while (true)
        { 
            transform.position=Vector3.MoveTowards(transform.position,GameManager.Instance.character.transform.position - _offset,camFollowSpeed);
            
            yield return new WaitForFixedUpdate();
        }
       
    }

    public IEnumerator CamZoom()
    {
      yield return  transform.DOMove(-transform.forward * 2, 0.35f).SetRelative().WaitForCompletion();
      while (true)
        {
             transform.RotateAround(GameManager.Instance.character.transform.position,new Vector3(0,1,0),0.5f);
             yield return new WaitForFixedUpdate();
        }

    
    }
 
}