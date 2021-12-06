using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interaction : MonoBehaviour
{
    bool interaction = false;
    public Transform target;
    
    public bool Interacting = false;

    float time;
    public Text Talk;
    public GameObject panel;
    
   static bool talk1 = false;
    static bool talk2 = false;
    static bool talk3 = false;

    public Button AcceptButton;
    public Button RefuseButton;

    public GameObject RefuseButtonObject;

    public bool ShotGun = false;

    void Start()
    {
        Button btn = AcceptButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        Button btn2 = RefuseButton.GetComponent<Button>();
        btn2.onClick.AddListener(TaskOnClick2);
    }
    void Update()
    {
        float dist = Vector3.Distance(target.position, transform.position);
        if (dist < 4)
        {
            interaction = true;
        }
        if (dist > 4)
        {
            interaction = false;
        }



        if (Interacting)
        {
            time += Time.deltaTime;
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Vector3 TargetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

            transform.LookAt(TargetPosition);


        }


        if (interaction)
        {

            if (Input.GetButtonDown("Interact") && talk1 == false && talk2 == false)
            {

                Interacting = true;
                Vector3 TargetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

                transform.LookAt(TargetPosition);
                ShotGun = true;
                panel.SetActive(true);
                Talk.text = "Thank you traveller! If it was not for you I would be dead! Here, take this shotgun as my thanks, I know you'll make a better use of it, you see, I'm a little bit rusty...";
                talk1 = true;

            }
            else
            if (Input.GetButtonDown("Interact") && talk1 == true && talk2 == false && talk3 == false)
            {
                Talk.text = "You're a bounty hunter, that's good, maybe you can help me out with a criminal gang that took over a smalltown nearby. Their boss is a pain in the ass but I think you can take him over with those skills";
                //TaskOnClick();
                Interacting = true;
                panel.SetActive(true);
                talk2 = true;

            }
        }
    }
    void TaskOnClick()
    {
        if (Interacting && talk1 && talk2 == false && talk3 == false)
        {
            Talk.text = "You're a bounty hunter, that's good, maybe you can help me out with a criminal gang that took over a smalltown nearby. Their boss is a pain in the ass but I think you can take him over with those skills";
            talk2 = true;
        } else
        if (Interacting&& talk1 && talk2 && talk3 == false)
        {
            Talk.text = "If you accept I'll take you now to the town, if not, you can come back later to me so I can guide you. By the way, the reward is one of the best Revolvers in the market, are you interested?";
            RefuseButtonObject.SetActive(true);
            talk3 = true;
        }else

        if (Interacting && talk1 && talk2 && talk3)
        {
            talk2 = false;
            talk3 = false;
            Interacting = false;
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(2);
        }
    }

    void TaskOnClick2()

    {
        if(Interacting && talk1 && talk2 && talk3)
        {
            RefuseButtonObject.SetActive(false);
            talk2 = false;
            talk3 = false;
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Interacting = false;
            panel.SetActive(false);
            RefuseButtonObject.SetActive(false);
        }
    }

        /* if (Input.GetButtonDown("Interact") && talk1 == false && talk2 == false)
         {

             Interacting = true;
             Vector3 TargetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

    transform.LookAt(TargetPosition);

             panel.SetActive(true);
             Talk.text = "Hello traveller, I'm the sheriff of this zone, I heard you are a bounty hunter. I think I've got the right job for you. If you make it, i'll get you a shotgun and maybe I'll give you another bandits to catch, are you ready?";
             if (Input.GetButtonDown("Interact") && time > 0.5 && talk1 == false)

             {

                 talk1 = true;
                 time = time - time;
             }

         }
         if (talk1)
         {

             Talk.text = "(Press the E key to accept the task or press R to cancel)";
             if (Input.GetButtonDown("Interact") && time > 0.5)
             {
                 talk1 = false;
                 talk2 = true;
                 time = time - time;
             }
             if (Input.GetButtonDown("Refuse") && time > 0.5)
             {
                 talk1 = false;
                 time = time - time;
                 Interacting = false;
                 panel.SetActive(false);
             }
         }
         if (talk2)
         {
             Talk.text = "Thank you for your assistance, your task is to kill the bandits that took out a small village next here. I want you to bring me the head of the leader, a man who uses two pistols. I will take you there now";
             if (Input.GetButtonDown("Interact") && time > 0.5)
             {
                 SceneManager.LoadScene(1);
             }
         }
     }
    }*/
    }

