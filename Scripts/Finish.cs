using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Finish : MonoBehaviour
{
    public int totalValue;
    public TextMeshProUGUI totalValueText;

    private void Start()
    {
        totalValueText.text = totalValue.ToString();
    }

    public void SetValue(int damage)
    {
        totalValue -= damage;
        totalValueText.text = totalValue.ToString();
        GameManager.instance.CheckFinish();
    }

}
