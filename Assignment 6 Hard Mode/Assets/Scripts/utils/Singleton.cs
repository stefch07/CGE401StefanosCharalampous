/*
 * Stefanos Charalampous
 * SingletonGameManager.cs
 * Assignment 6 - Hard Mode
 * Manages asynchronous loading and unloading of levels as a singleton.
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class SingletonGameManager : MonoBehaviour
{
    public static SingletonGameManager instance;

    private string currentLevelName = string.Empty;

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
            Debug.LogError("Attempted second instance of Singleton GameManager");
        }
    }

    public void LoadLevel(string levelName)
    {
        if (!string.IsNullOrEmpty(currentLevelName))
        {
            UnloadLevel(currentLevelName);
        }

        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to load level " + levelName);
            return;
        }
        currentLevelName = levelName;
    }

    public void UnloadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level " + levelName);
            return;
        }
        currentLevelName = string.Empty;
    }
}