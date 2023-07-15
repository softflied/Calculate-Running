using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Operation : MonoBehaviour
{
    public string operation;
    public TextMeshProUGUI operationText;

    private void Start()
    {
        operationText.text = operation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && other.transform.name.Equals("MainPlayer"))
        {

            switch (operation)
            {
                case "+":
                    CalculateManager.instance.operation = CalculateManager.Operations.Addition;
                    break;
                case "-":
                    CalculateManager.instance.operation = CalculateManager.Operations.Subtraction;
                    break;
                case "x":
                    CalculateManager.instance.operation = CalculateManager.Operations.Multiplication;
                    break;
                case "/":
                    CalculateManager.instance.operation = CalculateManager.Operations.Division;
                    break;
            }

            CalculateManager.instance.StartToSpawn();

                Destroy(this.gameObject);
           
        }
    }
}
