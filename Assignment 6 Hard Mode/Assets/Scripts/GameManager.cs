using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public int score;
    public GameObject pauseMenu;
    private string CurrentLevelName = string.Empty;
    
    // #region This code makes this class a Singleton
    // public static GameManager instance; // Made instance public to allow other classes to access it
    // private void Awake()
    // {
    //     if (instance == null)
    //     {
    //         instance = this;
    //         DontDestroyOnLoad(gameObject);
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //         Debug.LogError("Trying to instantiate a second instance of singleton GameManager");
    //     }
    // }
    // #endregion
public void LoadLevel(string levelName)
{
    AsyncOperation ao = SceneManager.LoadSceneAsync(levelName);
    if (ao == null)
    {
        Debug.LogError("[GameManager] Unable to load level " + levelName);
        return;
    }
    CurrentLevelName = levelName;
}
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
    public void UnloadCurrentLevel()
    {
         AsyncOperation ao = SceneManager.UnloadSceneAsync(CurrentLevelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level " + CurrentLevelName); // Added a space for readability
            return;
        }
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }
     public void Unpause()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
  private void Update()
{
    if (Input.GetKeyDown(KeyCode.P))
    {
        Debug.Log("P key was pressed.");
        if (Time.timeScale == 0f)
        {
            Unpause();
        }
        else
        {
            Pause();
        }
    }
}
}