using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Obstacle : MonoBehaviour,IHandGrow
{
    // Start is called before the first frame update
    public float rotateSpeed = 500f;
    public float moveSpeed = 50f;
    public int direction = 1;
    public float rangeX = 2f;

    [System.Flags]
    public enum ObstacleState
    {
        Rotate,
        Move,
      
    }
    public ObstacleState ObstacleEnum;
    
   
    private void Start()
    {
        
        if (ObstacleEnum.HasFlag(ObstacleState.Move))
            MoveObstacle();
       
            
        if (ObstacleEnum.HasFlag(ObstacleState.Rotate))
            RotateObstacle();
       
    }

    public void DecreaseStack()
    {
        GameManager.Instance.currentStack--;
    }


    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if (character&&GameManager.Instance.currentStack>0)
        {
            DecreaseStack();
            ChangeHandScale();
        }
    }

    public void RotateObstacle()
    {
    
     
        transform.DORotate(new Vector3(0,0,1), rotateSpeed).SetLoops(-1, LoopType.Incremental).SetSpeedBased().SetRelative();
    
    }

    public void MoveObstacle()
    {
        Vector3 pos = transform.right *rangeX*direction;
        transform.DOMove(pos, moveSpeed).SetLoops (-1, LoopType.Yoyo).SetRelative().SetEase(Ease.Linear);
    }

    public void ChangeHandScale()
    {
        GameManager.Instance.leftHand.DOScale(-GameManager.Instance.handScaleRate, 0.25f).SetRelative().SetEase(Ease.Linear);
        GameManager.Instance.rightHand.DOScale(-GameManager.Instance.handScaleRate, 0.25f).SetRelative().SetEase(Ease.Linear);
    }
}
