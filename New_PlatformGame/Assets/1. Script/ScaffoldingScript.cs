﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.PlayerConnection;

public class ScaffoldingScript : MonoBehaviour
{
    public GameObject coinPrefab;
    public const int percentage = 30;
    void Start()
    {
        int random = Random.Range(1, 10);
        Debug.Log(random);
        if (random <= 3)
        {
            Instantiate(coinPrefab, transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
        }
    }
}
