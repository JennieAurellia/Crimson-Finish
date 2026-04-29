using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    [Header("NewGame Button")]
    [SerializeField] private Button newGameBtn;
    [Header("Continue Button")]
    [SerializeField] private Button continueBtn;

    void Start()
    {
        GameManager.Instance.CheckSaveFile();
        levelCurrent = GameManager.Instance.levelCurrent;
        DisableContinueButton();
    }

    #region Level Interface Management
    [Header("Level")]
    public int levelCurrent;
    public int sceneIndex = 0;
    private void DisableContinueButton()
    {
        if (GameManager.Instance.levelCurrent == 0)
        {
            continueBtn.gameObject.SetActive(false);
        }
        else
        {
            continueBtn.gameObject.SetActive(true);
        }
    }

    public void NewGame()
    {
        GameManager.Instance.ResetLevel();
        levelCurrent = GameManager.Instance.levelCurrent;
        GameManager.Instance.ChangeScene(levelCurrent);
    }

    public void Continue()
    {
        GameManager.Instance.ChangeScene(levelCurrent);
    }

    #endregion

}