using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class UIMenu : MonoBehaviour
{
    [Header("NewGame Button")]
    [SerializeField] private Button newGameBtn;
    [Header("Continue Button")]
    [SerializeField] private Button continueBtn;
    [Header("Menu Panel GameObject")]
    [SerializeField] private GameObject menu;
    [Header("Setting Panel GameObject")]
    [SerializeField] private GameObject setting;

    void Start()
    {
        GameManager.Instance.CheckUserSettingSaveFile();
        GetVolumeValue();
        SetVolume();

        GameManager.Instance.CheckSaveFile();
        levelCurrent = GameManager.Instance.levelCurrent;
        DisableContinueButton();

        menu.SetActive(true);
        setting.SetActive(false);
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
        Debug.Log("New Game");
        GameManager.Instance.ResetLevel();
        levelCurrent = GameManager.Instance.levelCurrent;
        GameManager.Instance.ChangeScene(levelCurrent);
    }

    public void Continue()
    {
        Debug.Log("Continue");
        GameManager.Instance.ChangeScene(levelCurrent);
    }

    #endregion

    #region Sound Management
    [Header("Volume Setting")]
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private TMP_Text masterTxt;
    [SerializeField] private TMP_Text musicTxt;
    [SerializeField] private TMP_Text sfxTxt;

    public void OpenSetting()
    {
        menu.SetActive(false);
        setting.SetActive(true);
    }
    public void CloseSetting()
    {
        menu.SetActive(true);
        setting.SetActive(false);

        GameManager.Instance.ChangeUserSetting(masterSlider.value, musicSlider.value, sfxSlider.value);
    }
    private void GetVolumeValue()
    {
        masterSlider.value = GameManager.Instance.masterVolumeCurrent;
        musicSlider.value = GameManager.Instance.musicVolumeCurrent;
        sfxSlider.value = GameManager.Instance.sfxVolumeCurrent;
    }
    public void SetVolume()
    {
        audioMixer.SetFloat("Master", Mathf.Log10(masterSlider.value) * 20);
        audioMixer.SetFloat("Music", Mathf.Log10(musicSlider.value) * 20);
        audioMixer.SetFloat("Sfx", Mathf.Log10(sfxSlider.value) * 20);

        masterTxt.text = Mathf.RoundToInt(masterSlider.value * 100).ToString();
        musicTxt.text = Mathf.RoundToInt(musicSlider.value * 100).ToString();
        sfxTxt.text = Mathf.RoundToInt(sfxSlider.value * 100).ToString();
    }
    public void ResetVolume()
    {
        GameManager.Instance.ResetUserSetting();
        GetVolumeValue();
        SetVolume();
    }

    #endregion

    public void ExitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

}