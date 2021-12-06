using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public Button QuitButton;
    public Button ReturnButton;
    public Button RetryButton;

    public GameObject Mira;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = QuitButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        Button btn2 = ReturnButton.GetComponent<Button>();
        btn2.onClick.AddListener(TaskOnClick2);

        Button btn3 = RetryButton.GetComponent<Button>();
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
       
        
        Time.timeScale = 1;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
        Mira.SetActive(true);
        SceneManager.LoadScene(1);

    }
        void TaskOnClick3()
    {
            Scene currentScene = SceneManager.GetActiveScene();

            // Retrieve the name of this scene.
            string sceneName = currentScene.name;

        if (sceneName == "SampleScene")
        {
            Time.timeScale = 1;

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.None;

            SceneManager.LoadScene(2);
        }
        if (sceneName == "Sheriff Spot")
        {
            Time.timeScale = 1;

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(1);
        }

    }
}
