using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CalculateManager : MonoBehaviour
{
   public static CalculateManager instance;
   private void Awake()
   {
      if (instance == null)
         instance = this;
   }

   public enum Operations
   {
      Addition, 
      Subtraction, 
      Multiplication, 
      Division
   }

   public Operations operation;
   public int firstNumber;
   public int secondNumber;
   public bool isFullFirstNumber;

   [SerializeField] private TextMeshProUGUI firstNumberText;
   [SerializeField] private TextMeshProUGUI operationText;
   [SerializeField] private TextMeshProUGUI secondNumberText;

   private void Start()
   {
      firstNumber = 0;
      secondNumber = 0;
      SetTexts();
   }


   public int ResultNumber()
   {
      switch (operation)
      {
         case Operations.Addition:
            SetTexts("+");
            return firstNumber + secondNumber;
            break; 
         
         case Operations.Division:
            SetTexts("/");
            return (int)(firstNumber / secondNumber);
            break;
         
         case Operations.Multiplication:
            SetTexts("x");
            return firstNumber * secondNumber;
            break; 
         
         case Operations.Subtraction:
            SetTexts("-");
            return firstNumber - secondNumber;
            break;
      }
      
      return 0;
   }

   public void StartToSpawn()
   {
      isFullFirstNumber = false;
      operationText.text = ".";
      GameManager.instance.SetActiveResultPanel(true);
      GameManager.instance.SetActiveOperationPanel(false);
      StartCoroutine(GameManager.instance.SpawnPlayers(ResultNumber()));
      
   }

   public void SetTexts(string operation)
   {
      operationText.text = operation;
      firstNumberText.text = firstNumber.ToString();
      secondNumberText.text = secondNumber.ToString();
      
   }
   
   public void SetTexts()
   {
      firstNumberText.text = firstNumber.ToString();
      secondNumberText.text = secondNumber.ToString();
   }
   public void ResetTexts()
   {
      operationText.text = ".";
      firstNumberText.text = 0.ToString();
      secondNumberText.text = 0.ToString();
      secondNumber = 0;

   }


}
