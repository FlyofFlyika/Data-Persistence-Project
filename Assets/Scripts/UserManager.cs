#region net namespaces
using System.Collections;
using System.Collections.Generic;
using System.IO;
#endregion

#region UNITY namespaces
using UnityEngine;
using UnityEngine.UI;
#endregion

public class UserManager : MonoBehaviour
{
    public static UserManager Instance;
    string fileSave;
    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        fileSave = Application.persistentDataPath + "/save.json";
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }
    #region Player Name
    string playerName;
    public void SetName(string newPlayerName)
    {
        playerName = newPlayerName;
    }
    public string GetName()
    {
        return playerName;
    }
    #endregion

    #region HighScore Save/load

    public class HighScore
    {
       public string playerName;
       public int score;
    }
    public HighScore highScore;
    public void Save(int score)
    {
        highScore.score = score;
        highScore.playerName = playerName;
        string json = JsonUtility.ToJson(highScore);
        File.WriteAllText(fileSave, json);
    }
    public void Load()
    {
        if (File.Exists(fileSave))
        {
            highScore = JsonUtility.FromJson<HighScore>(File.ReadAllText(fileSave));
        }
        else
        {
            Debug.Log(fileSave);
            highScore = new HighScore();
            highScore.playerName = "AAA";
            highScore.score = 0;
        }
    }
    public void UpdateHighScore(Text hScore)
    {

        hScore.text = "Best Score:" + highScore.playerName + ":" + highScore.score;
    }
    #endregion
}
