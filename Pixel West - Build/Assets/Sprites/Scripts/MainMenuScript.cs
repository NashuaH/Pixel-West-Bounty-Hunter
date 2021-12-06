using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public Button QuitButton;
    public Button PlayButton;
    public Button SettingsButton;

    public GameObject SettingUI;
    public GameObject MainMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = QuitButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        Button btn2 = PlayButton.GetComponent<Button>();
        btn2.onClick.AddListener(TaskOnClick2);

        Button btn3 = SettingsButton.GetComponent<Button>();
        btn3.onClick.AddListener(TaskOnClick3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TaskOnClick()
    {
        Application.Quit();
    }
    void TaskOnClick2()
    {
        SceneManager.LoadScene(1);
    }
    void TaskOnClick3()
    {
        MainMenuUI.SetActive(false);
        SettingUI.SetActive(true);
    }
}
