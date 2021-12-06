using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public GameObject Boss;
    public GameObject YouWonUI;
    public Button QuitButton;
    public Button MainMenuButton;



    void Start()
    {
        Button btn = QuitButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        Button btn2 = MainMenuButton.GetComponent<Button>();
        btn2.onClick.AddListener(TaskOnClick2);

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Boss == false)
        {
            Time.timeScale = 0;
           
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            YouWonUI.SetActive(true);
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
   
}
