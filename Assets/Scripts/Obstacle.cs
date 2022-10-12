using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using Random = System.Random;

public class Obstacle : MonoBehaviour,IHandGrow
{
    // Start is called before the first frame update
    public float rotateSpeed = 500f;
    public float moveSpeed = 50f;
    public int direction = 1;
    public float rangeX = 2f;
    public float randDelayRange;
    [System.Flags]
    public enum ObstacleState
    {
        Rotate,
        Move,
        UpDown
      
    }
    public ObstacleState ObstacleEnum;
    
   
    private void Start()
    {
        
        if (ObstacleEnum.HasFlag(ObstacleState.Move))
            MoveObstacle();
       
            
        if (ObstacleEnum.HasFlag(ObstacleState.Rotate))
            RotateObstacle();
        if (ObstacleEnum.HasFlag(ObstacleState.UpDown))
        {
            UpDownObstacle();
        }
       
    }

    public void DecreaseStack()
    {
        GameManager.Instance.currentStack--;
        UIManager.Instance.SetStackTxt();
        UIManager.Instance.FillProgressBar();
    }


    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();
        Instantiate(GameManager.Instance.smashParticle, transform.position+Vector3.up*1.5f, quaternion.identity);
        if (character&&GameManager.Instance.currentStack>0)
        {
            GameManager.Instance.PlayAudio(GameManager.Instance.obstacleClip);
            DecreaseStack();
            ChangeHandScale();
        }
    }

    public void RotateObstacle()
    {
    
     
        transform.DORotate(new Vector3(0,0,1), rotateSpeed).SetLoops(-1, LoopType.Incremental).SetSpeedBased().SetRelative();
    
    }

    public void UpDownObstacle()
    {
        float delay= UnityEngine.Random.Range(0, randDelayRange);
        float posY =  rangeX*direction;
        transform.DOMoveY(posY, moveSpeed).SetLoops (-1, LoopType.Yoyo).SetRelative().SetEase(Ease.Linear).SetDelay(delay);
    }
    public void MoveObstacle()
    {
       float delay= UnityEngine.Random.Range(0, randDelayRange);
        Vector3 pos = transform.right *rangeX*direction;
        transform.DOMove(pos, moveSpeed).SetLoops (-1, LoopType.Yoyo).SetRelative().SetEase(Ease.Linear).SetDelay(delay);
    }

    public void ChangeHandScale()
    {
        GameManager.Instance.leftHand.DOScale(-GameManager.Instance.handScaleRate, 0.25f).SetRelative().SetEase(Ease.Linear);
        GameManager.Instance.rightHand.DOScale(-GameManager.Instance.handScaleRate, 0.25f).SetRelative().SetEase(Ease.Linear);
    }
}
