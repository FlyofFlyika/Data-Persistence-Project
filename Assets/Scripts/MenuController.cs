#region net namespaces
using System.Collections;
using System.Collections.Generic;
#endregion

#region UNITY namespaces
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

#endregion

public class MenuController : MonoBehaviour
{
    public Text playerName;
    public Text HighScoreText;
    private void Start()
    {

        UserManager.Instance.UpdateHighScore(HighScoreText);
    }
    public void StartNew()
    {
        UserManager.Instance.SetName(playerName.text);
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
