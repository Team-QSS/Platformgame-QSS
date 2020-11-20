using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PauseButtonScript : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject returnButton;
    public GameObject mainMenuButton;
    public GameObject settingButton;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Pause);

        returnButton.GetComponent<Button>().onClick.AddListener(Play);
        settingButton.GetComponent<Button>().onClick.AddListener(Settings);
        mainMenuButton.GetComponent<Button>().onClick.AddListener(GotoMainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    private void Play()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        
    }

    private void GotoMainMenu()
    {
        
    }

    private void Settings()
    {
        
    }
}
