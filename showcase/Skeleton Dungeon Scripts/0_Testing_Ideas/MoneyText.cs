using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyText : MonoBehaviour
{
    public static int Coin;
    public TextMeshProUGUI coinTextUI;

    void Start()
    {
        coinTextUI = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        coinTextUI.text = Coin.ToString();
    }
}
