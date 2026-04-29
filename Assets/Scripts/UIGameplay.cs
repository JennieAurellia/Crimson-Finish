using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGameplay : MonoBehaviour
{
    [Header("Scene Index")]
    [SerializeField] private int sceneIndex = 0;

    [Header("Pause Menu")]
    public TMP_Text pauseTxt;
    public Button resumeBtn;
    public Button menuBtn;

    void Start()
    {
        menuBtn.onClick.AddListener(() => GameManager.Instance.ChangeScene(sceneIndex));
        resumeBtn.onClick.AddListener(PauseMenuHandle);

        PauseMenuSetActiveChild(false);
        gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenuHandle();
        }
    }

    private void PauseMenuHandle()
    {
        if (GameManager.Instance.isPaused)
        {
            GameManager.Instance.Resume();
            
            PauseMenuSetActiveChild(false);
        }
        else
        {
            GameManager.Instance.Pause();

            PauseMenuSetActiveChild(true);
        }
    }

    private void PauseMenuSetActiveChild(bool active)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(active);
        }
    }

}
