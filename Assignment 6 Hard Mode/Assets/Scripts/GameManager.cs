using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    private string CurrentLevelName = string.Empty;
    
    #region This code makes this class a Singleton
    public static GameManager instance; // Made instance public to allow other classes to access it
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Debug.LogError("Trying to instantiate a second instance of singleton GameManager");
        }
    }
    #endregion

    public void UnloadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level " + levelName); // Added a space for readability
            return;
        }
        CurrentLevelName = levelName;
    }
}