using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using PunchRunner.Interfaces;
using PunchRunner.Managers;
using UnityEngine;

public class Wall : MonoBehaviour,IHandGrow
{
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        Character character = other.transform.GetComponent<Character>();
      
        
        if (GameManager.Instance.leftHand.transform.localScale.x<=1.2f&&character)
        {
            other.enabled = false;
            GameManager.Instance.Win();
        }
        else if(character)
        {
            ChangeHandScale();
            character.wall = this;
            StartCoroutine("WaitForPunch");
        }
    }

    

   
    IEnumerator WaitForPunch()
    {
        GameManager.Instance.isPunch = true;
        yield return new WaitForSeconds(1.1f);
        GameManager.Instance.isPunch = false;
    }

    public void ChangeHandScale()
    {
        GameManager.Instance.leftHand.DOScale(-GameManager.Instance.handScaleRate, 0.25f).SetRelative().SetEase(Ease.Linear);
        GameManager.Instance.rightHand.DOScale(-GameManager.Instance.handScaleRate, 0.25f).SetRelative().SetEase(Ease.Linear);
    }
}
