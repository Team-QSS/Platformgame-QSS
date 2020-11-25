using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

// UI 적용 함수 모음
// UIScriptObject에 넣음
public class UIFunction : MonoBehaviour
{
    private int _sceneNumber;
    private void Start()
    {
        _sceneNumber = SceneManager.GetActiveScene().buildIndex;
    }

    public void GoBackScene()
    {
        SceneManager.LoadScene(_sceneNumber - 1);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(_sceneNumber);
    }

    public void GoNextScene()
    {
        SceneManager.LoadScene(_sceneNumber + 1);
    }

    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
