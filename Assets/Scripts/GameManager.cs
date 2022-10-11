using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
    // Start is called before the first frame update
{
    public Character character;
    public bool isPunch = false;
    public int money,moneyRate;
    public Animator characterAnim;
    public bool tapToPlay = false;
     public bool isFinishLevel = false;
    public int currentStack, maxStack;
    public string state = "IdleRoutine";
    public Transform leftHand, rightHand;
    public float handScaleRate = 0.2f;
    public CameraFollow cameraFollow;
    private void Start()
    {
        StartGame();
    }



    void StartGame()
    {
       
       
        cameraFollow = FindObjectOfType<CameraFollow>();
        cameraFollow.StartCoroutine("FollowRoutine");
        characterAnim = character.transform.GetComponentInChildren<Animator>();
        StartCoroutine("DecisionAnimRoutine");
        StartCoroutine(state);
     
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)&&!tapToPlay)
        {
            character.StartCoroutine("MoveRoutine");
           InputPanel.Instance.OnDragDelta.AddListener(character.Drag);

            tapToPlay = true;

        }
    }

    string currentAnimation;
    public void RegisterAnimation(string value)
    {

        if (value == currentAnimation)
            return;
        
        print("Idlee");
        currentAnimation = value;
       
        characterAnim.CrossFade(currentAnimation,0.25f);
    }
    
    
    public void ChangeState(string value)
    {
        if (state == value)
            return;
        state = value;
    }
    
    public  IEnumerator DecisionAnimRoutine()
    {
        
        while (true)
        {
            if (!tapToPlay)
            {
                print("false");
                ChangeState("IdleRoutine");
            }
           else if(isPunch)
                ChangeState("PunchRoutine");
            else if(isFinishLevel )
                ChangeState("DanceRoutine");
            else if (currentStack<maxStack)
                ChangeState("Run1Routine");
            else
                ChangeState("Run2Routine");
           
           
            yield return  null;
        }
    }
    
    
    IEnumerator IdleRoutine()
    { 
        
        if (state=="IdleRoutine")
        {
            RegisterAnimation("Idle");
            yield return null;
        }

        StartCoroutine(state);
    }
    
    IEnumerator DanceRoutine()
    { 
        
        if (state=="DanceRoutine")
        {
            RegisterAnimation("Dance");
      
            yield return null;
        }

        StartCoroutine(state);
    }
    IEnumerator Run1Routine()
    { 
        
        if (state=="Run1Routine")
        {
            RegisterAnimation("Run");
            yield return null;
        }

        StartCoroutine(state);
    }
    
    IEnumerator Run2Routine()
    { 
        
        if (state=="Run2Routine")
        {
            RegisterAnimation("Run2");
            yield return null;
        }

        StartCoroutine(state);
    }
    IEnumerator PunchRoutine()
    { 
        
        if (state=="PunchRoutine")
        {
            RegisterAnimation("punch");
            
            yield return null;
        }

        StartCoroutine(state);
    }

 

   

}
