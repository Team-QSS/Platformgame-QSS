using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Text scoreText;
    public GameObject player;
    private int _score;

    void Update()
    {
        SetScore();
    }

    void SetScore()
    {
        _score = player.GetComponent<GameManager>().score;
        scoreText.text = _score + "M";
    }
}
