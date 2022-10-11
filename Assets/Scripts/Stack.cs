using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : Collectables,IStackState
{
    // Start is called before the first frame update
   
    public override void IncreaseValue()
    {

        GameManager.Instance.currentStack++;

    }
    public override void CollectItem()
    {
        transform.gameObject.SetActive(false);
    }

    public bool isStackFull()
    {
        if (GameManager.Instance.currentStack < GameManager.Instance.maxStack)
            return false;
        else
            return true;
    }

    protected override  void OnTriggerEnter(Collider other)
    {
        Character character=  other.transform.GetComponent<Character>();

        if (!isStackFull()&&character)
        {
            IncreaseValue();
            CollectItem();
        }
      
       
    }
}


