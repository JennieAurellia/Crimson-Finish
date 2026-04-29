using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using Debug = UnityEngine.Debug;

public class GameManager : MonoBehaviour
{
    #region GameManager

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // public void GameManagerCheck()
    // {
    //     Debug.Log("GameManager is working");
    // }
    #endregion

    #region Game Management
    public bool isPaused;
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }
    #endregion

    #region Level Manager
    LevelData levelData;
    public int levelCurrent;

    //berguna untuk Check Save File ada atau tidak
    public void CheckSaveFile()
    {
        if (File.Exists(Application.dataPath + "/Level.json")) LoadLevel();
        else SaveLevel();
    }
    //berguna untuk save level ke json
    private void SaveLevel()
    {
        levelData = new LevelData();
        levelData.level = levelCurrent;
        string json = JsonUtility.ToJson(levelData, true);
        File.WriteAllText(Application.dataPath + "/Level.json", json);
    }
    //berguna untuk load level dari json
    private void LoadLevel()
    {
        string json;
        json = File.ReadAllText(Application.dataPath + "/Level.json");
        LevelData levelData = JsonUtility.FromJson<LevelData>(json);
        levelCurrent = levelData.level;
    }
    //berguna untuk Load Level dan assign ke game manager
    private void CheckLevel()
    {
        LoadLevel();
        levelCurrent = levelData.level;
    }
    //berguna untuk mengganti nilai level / assign level
    public void ChangeLevel(int newLevelUnlocked)
    {
        levelCurrent = newLevelUnlocked;
        SaveLevel();
    }
    //berguna untuk reset level
    public void ResetLevel()
    {
        levelCurrent = 1;
        SaveLevel();
    }

    #endregion

}
