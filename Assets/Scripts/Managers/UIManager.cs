using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PunchRunner.Managers
{
    public class UIManager : MonoSingleton<UIManager>
    {
        // Start is called before the first frame update
        public Button upgradeBtn;
 
        public TextMeshProUGUI fullStackTxt;
        public TextMeshProUGUI collectedCurrencyTxt;
        public TextMeshProUGUI upgradePriceTxt;
        public TextMeshProUGUI totalCurrencyTxt;
        public TextMeshProUGUI  StackTxt;
  
        public TextMeshProUGUI lvlTxt;
        public GameObject tapToPlayPanel, inGamePanel, endPanel;
        public Image fillImg;

        public void SetUpgradeText()
        {
            upgradePriceTxt.text = GameManager.Instance.upgradePrice.ToString();
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
        
       
       
            float amount= ((float)GameManager.Instance.currentStack)/GameManager.Instance.maxStack;
     
            fillImg.DOFillAmount((float)amount, 0.3f);
    
        }
    }
}
