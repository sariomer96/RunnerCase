using UnityEngine;

namespace PunchRunner.Managers
{
    public class UpgradeManager : MonoSingleton<UpgradeManager>
    {
        // Start is called before the first frame update
   
        public void CurrencyCheck()
        {
            if (GameManager.Instance.money>=GameManager.Instance.upgradePrice)
                UIManager.Instance.upgradeBtn.interactable = true;
            else
                UIManager.Instance.upgradeBtn.interactable = false;
        }

        public void IncreasePurchase()
        {
            GameManager.Instance.money -= GameManager.Instance.upgradePrice;
            GameManager.Instance.upgradePrice = (int)Mathf.Pow(GameManager.Instance.baseExpValue, GameManager.Instance.expRate);
            GameManager.Instance.maxStack += GameManager.Instance.maxStackIncreaseRate;
            UIManager.Instance.SetUpgradeText();
            UIManager.Instance.SetTotalCurrencyText();
            UIManager.Instance.SetStackTxt();
            GameManager.Instance.expRate++;
            GameManager.Instance.SaveData();
            // save price


        }
    
 
    }
}
