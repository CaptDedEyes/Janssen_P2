using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardValue : MonoBehaviour
{
    public int amount = 1;
    public Text amountText;

    private void Awake()
    {
        amountText.text = amount.ToString();
    }
}
