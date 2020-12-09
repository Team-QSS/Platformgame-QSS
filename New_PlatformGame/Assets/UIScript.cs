using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreText;
    private int _score;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetScore();
    }

    void SetScore()
    {
        _score = player.GetComponent<GameManager>()._score;
        scoreText.text = _score + "M";
    }
}
