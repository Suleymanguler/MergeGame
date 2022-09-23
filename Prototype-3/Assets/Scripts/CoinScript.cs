using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinScript : MonoBehaviour
{
    
       
        public TextMeshProUGUI coinAmountText;
        int coinAmount;

    private void Start()
    {
        coinAmountText = GameObject.Find("coinAmountText").GetComponent<TextMeshProUGUI>();
        coinAmount=PlayerPrefs.GetInt("coinAmount");
        coinAmountText.text = coinAmount.ToString();

  
    }
    public void raiseGold(int coinRaiseAmount)
        {
            
            coinAmount = PlayerPrefs.GetInt("coinAmount");
            coinAmount += coinRaiseAmount;
            coinAmountText.text = coinAmount.ToString();
            PlayerPrefs.SetInt("coinAmount", coinAmount);
        }
    
}
