using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string currentPlayerName;
    public string bestPlayerName;
    public int bestScore;

    private void Awake()
    {
        Debug.Log("Manager Awake!");
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        currentPlayerName = "Unknown";
        loadHighestScore();
        DontDestroyOnLoad(gameObject);
    }

    public string createBestScoreText()
    {
        return "Best Score: " + bestPlayerName + " : " + bestScore;
    }

    public void updateScore(int currentScore)
    {
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            bestPlayerName = currentPlayerName;
            saveScore();
        }
    }

    private void loadHighestScore()
    {
        string path = Application.persistentDataPath + "/score.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            ScoreData scoreData = JsonUtility.FromJson<ScoreData>(json);
            bestPlayerName = scoreData.playerName;
            bestScore = scoreData.score;
        }
        else
        {
            bestPlayerName = "";
            bestScore = 0;
        }
    }

    private void saveScore()
    {
        string path = Application.persistentDataPath + "/score.json";
        string json = JsonUtility.ToJson(new ScoreData(bestPlayerName, bestScore));
        File.WriteAllText(path, json);
    }
}
