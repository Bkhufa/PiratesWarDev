﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    public static int coinValue;
    Text coin;
    // Start is called before the first frame update
    void Start()
    {
        coin = GetComponent<Text> ();
        // coinValue = 100;
    }

    // Update is called once per frame
    void Update()
    {
        coin.text = " " + coinValue;
    }
}
