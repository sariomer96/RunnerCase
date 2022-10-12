using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    // Start is called before the first frame update

    public virtual void IncreaseValue()
    {
        GameManager.Instance.money += GameManager.Instance.moneyRate;
        GameManager.Instance.collectedCurrency += GameManager.Instance.moneyRate;
        PlayerPrefs.SetInt("currency",GameManager.Instance.money);
        UIManager.Instance.SetTotalCurrencyText();
    }

    public virtual void CollectItem()
    {
        transform.gameObject.SetActive(false);
    }

 
    protected virtual  void OnTriggerEnter(Collider other)
    {
      Character character=  other.transform.GetComponent<Character>();

      if (character)
      {
          
          IncreaseValue();
          CollectItem();
      }
         
       
    }
}
