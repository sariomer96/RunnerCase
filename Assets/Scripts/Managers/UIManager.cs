using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    // Start is called before the first frame update
   public Button upgradeBtn;
 
    public TextMeshProUGUI fullStackTxt;
    public TextMeshProUGUI upgradePriceTxt;


    public void SetUpgradeText()
    {
        upgradePriceTxt.text = GameManager.Instance.upgradePrice.ToString()+"$";
    }
}
