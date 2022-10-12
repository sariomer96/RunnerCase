using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    // Start is called before the first frame update
   public Button upgradeBtn;
 
    public TextMeshProUGUI fullStackTxt;
    public TextMeshProUGUI collectedCurrencyTxt;
    public TextMeshProUGUI upgradePriceTxt;
    public TextMeshProUGUI totalCurrencyTxt;
    public TextMeshProUGUI  StackTxt;
    public TextMeshProUGUI tapToPlayCurrencyTxt;
    public TextMeshProUGUI lvlTxt;
    public GameObject tapToPlayPanel, inGamePanel, endPanel;
    public Image fillImg;

    public void SetUpgradeText()
    {
        upgradePriceTxt.text = GameManager.Instance.upgradePrice.ToString()+"$";
    }

    public void SetTotalCurrencyText()
    {
        totalCurrencyTxt.text = GameManager.Instance.money.ToString();
        collectedCurrencyTxt.text = GameManager.Instance.collectedCurrency.ToString();
    }

    public void SetStackTxt()
    {
        StackTxt.text = GameManager.Instance.currentStack + " / " + GameManager.Instance.maxStack;
    }

    public void FillProgressBar()
    {
        print(GameManager.Instance.currentStack+"  "+GameManager.Instance.maxStack);
       
       
        float t = ((float)GameManager.Instance.currentStack)/GameManager.Instance.maxStack;
        print(t+"T");
        fillImg.DOFillAmount((float)t, 0.3f);
    
    }
}
