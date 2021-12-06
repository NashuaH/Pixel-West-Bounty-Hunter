using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScrip : MonoBehaviour
{
    public GameObject PauseUI;
    public GameObject SettingUI;
    public Button QuitButton;
    public Button MainMenuButton;
    public Button SettingsButton;
    public Button BackGameButton;

    public GameObject Mira;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Button btn = QuitButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        Button btn2 = MainMenuButton.GetComponent<Button>();
        btn2.onClick.AddListener(TaskOnClick2);

        Button btn3 = SettingsButton.GetComponent<Button>();
        btn3.onClick.AddListener(TaskOnClick3);

        Button btn4 = BackGameButton.GetComponent<Button>();
        btn4.onClick.AddListener(TaskOnClick4);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Refuse"))
        {
            Mira.SetActive(false);
            Time.timeScale = 0;
            PauseUI.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        

    }
    void TaskOnClick()
    {
        Application.Quit();
    }
    void TaskOnClick2()
    {
        SceneManager.LoadScene(0);
    }
    void TaskOnClick3()
    {
        PauseUI.SetActive(false);
        SettingUI.SetActive(true);
    }
    void TaskOnClick4()
    {
        Mira.SetActive(true);
        PauseUI.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
