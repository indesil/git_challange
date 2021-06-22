using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class ScoreData
{
    public string playerName;
    public int score;

    public ScoreData(string pn, int s) {
        playerName = pn;
        score = s;
    }
}
