#region net namespaces
using System.Collections;
using System.Collections.Generic;
#endregion

#region UNITY namespaces
using UnityEngine;
#endregion

public class UserManager : MonoBehaviour
{
    public static UserManager Instance;
    string playerName;
    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void SetName(string newPlayerName)
    {
        playerName = newPlayerName;
    }
    public string GetName()
    {
        return playerName;
    }
}
