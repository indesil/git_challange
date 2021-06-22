using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    private const int mainSceneIndex = 1;

    public Text BestScoreText;

    private void Start()
    {
        Debug.Log("started menu handler");
        BestScoreText.text =  GameManager.Instance.createBestScoreText();
    }
    public void SavePlayerName(string value)
    {        
        GameManager.Instance.currentPlayerName = value;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(mainSceneIndex);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
    }
}
