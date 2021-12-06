using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsScript : MonoBehaviour
{
    

    public AudioMixer audioMixer;
    Resolution[] resolutions;

    public Dropdown resolutionDropdown;

    public Button BackButton;
    public GameObject PausePanel;
    public GameObject SettingPanel;

    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && 
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        Button btn = BackButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

    }

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    void TaskOnClick()
    {
        PausePanel.SetActive(true);
        SettingPanel.SetActive(false);
    }
}
