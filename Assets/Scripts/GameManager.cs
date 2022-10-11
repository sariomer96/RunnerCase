using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
    // Start is called before the first frame update
{
    public Character _character;
    public int money,moneyRate;
    public Animator characterAnim;
    public bool tapToPlay = false;
     public bool isFinishLevel = false;
    public int currentStack, maxStack;
    public string state = "IdleRoutine";
    public Transform leftHand, rightHand;
    public float handScaleRate = 0.2f;
    private void Start()
    {
        StartGame();
    }



    void StartGame()
    {
        _character = FindObjectOfType<Character>();
        characterAnim = _character.transform.GetComponentInChildren<Animator>();
        StartCoroutine("DecisionAnimRoutine");
        StartCoroutine(state);
     
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)&&!tapToPlay)
        {
            _character.StartCoroutine("MoveRoutine");
           InputPanel.Instance.OnDragDelta.AddListener(_character.Drag);

            tapToPlay = true;

        }
    }

    string currentAnimation;
    public void RegisterAnimation(string value)
    {
        print("Idl111ee");
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

}
