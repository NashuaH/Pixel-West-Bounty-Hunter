using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelControl : MonoBehaviour
{
    public Interaction IntScript;
    public GameObject Enemies;
    // Start is called before the first frame update
   private static bool  NoEnemy = false;
    public ChangeWeapon CWScript;

    static bool Tutorial = false;
    public GameObject TutorialPanel;
    public Button tutorialButton;

    void Start()
    {
        Button btn = tutorialButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Tutorial == false)
        {
           
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            TutorialPanel.SetActive(true);
        }
        else
        {
            //Time.timeScale = 1;
            TutorialPanel.SetActive(false);

           // Cursor.visible = false;
           // Cursor.lockState = CursorLockMode.Locked;
        }
        if (NoEnemy)
        {
            Enemies.SetActive(false);
        }
        if (IntScript.ShotGun)
        {
            NoEnemy = true;
            CWScript.shotgunAgain = true;
}
    }
    void TaskOnClick()
    {
        TutorialPanel.SetActive(false);
        Tutorial = true;
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }
}


