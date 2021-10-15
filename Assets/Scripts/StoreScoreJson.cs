using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StoreScoreJson : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StoreScore score = new StoreScore();

        score.HighScore = PlayerPrefs.GetInt("HighScore", 0);

        string jsonHighScore = JsonUtility.ToJson(score);

        // Store highe score to a json file.
        File.WriteAllText(Application.dataPath + "/highScore.json", jsonHighScore);
    }    
}
