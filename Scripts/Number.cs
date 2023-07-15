using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Number : MonoBehaviour
{
    public int number;
    public TextMeshProUGUI numberText;

    private void Start()
    {
        numberText.text = number.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && other.transform.name.Equals("MainPlayer"))
        {
            GameManager.instance.SetActiveResultPanel(false);
            GameManager.instance.SetActiveOperationPanel(true);
            
            if (!CalculateManager.instance.isFullFirstNumber)
            {
                CalculateManager.instance.ResetTexts();
                CalculateManager.instance.firstNumber = number;
                CalculateManager.instance.isFullFirstNumber = true;
                CalculateManager.instance.SetTexts();
            }
            else
            {
                CalculateManager.instance.secondNumber = number;
                CalculateManager.instance.SetTexts();
            }
            
            Destroy(this.gameObject);
           
        }
    }
}
