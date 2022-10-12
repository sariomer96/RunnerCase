using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stack : Collectables,IStackState
{
    // Start is called before the first frame update
   
    public override void IncreaseValue()
    {

        GameManager.Instance.currentStack++;
        UIManager.Instance.SetStackTxt();
        UIManager.Instance.FillProgressBar();

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
            GameManager.Instance.character.ChangeHandScale();
            GameManager.Instance.character.SpeedUp();
        }
        else
        {

            StartCoroutine("FullStackWarning");

        }
       
    }

    IEnumerator FullStackWarning()
    {
        UIManager.Instance.fullStackTxt.text = GameManager.Instance.fullStack;
            
        UIManager.Instance.fullStackTxt.transform.DORewind ();
        UIManager.Instance.fullStackTxt.transform.DOShakeScale(0.78f, 0.25f);
        yield return new WaitForSeconds(0.8f);
        UIManager.Instance.fullStackTxt.text = "";
    }
 
}


