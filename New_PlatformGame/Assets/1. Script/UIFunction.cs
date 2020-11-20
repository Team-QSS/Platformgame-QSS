using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFunction : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }
}
