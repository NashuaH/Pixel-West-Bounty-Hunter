using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    public GameObject Revolver1;
    public GameObject Revolver2;
    public GameObject ShotGun1;

    bool timerControl = false;

    float time;
     
  static bool ShotGun = false;


    public bool shotgunAgain = false;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (shotgunAgain)
        {
            ShotGun = true;
        }
        if (timerControl)
        {
            time += Time.deltaTime;
            if (time > 0.1)
            {
               
                if (ShotGun)
                {
                    if (Revolver1.activeSelf && Input.GetAxis("Mouse ScrollWheel") > 0)
                    {

                        Revolver1.SetActive(false);
                        Revolver2.SetActive(false);
                        ShotGun1.SetActive(true);
                        time = 0;
                        timerControl = false;

                    }else
                    if (Revolver1.activeSelf && Input.GetAxis("Mouse ScrollWheel") < 0)
                    {

                        Revolver1.SetActive(false);
                        Revolver2.SetActive(true);
                        ShotGun1.SetActive(false);
                        time = 0;
                        timerControl = false;

                    }
                    else 
                    if (Revolver2.activeSelf && Input.GetAxis("Mouse ScrollWheel") < 0)
                    {

                        Revolver1.SetActive(false);
                        Revolver2.SetActive(false);
                        ShotGun1.SetActive(true);
                        time = 0;
                        timerControl = false;

                    }else
                    if (Revolver2.activeSelf && Input.GetAxis("Mouse ScrollWheel") > 0)
                    {

                        Revolver1.SetActive(true);
                        Revolver2.SetActive(false);
                        ShotGun1.SetActive(false);
                        time = 0;
                        timerControl = false;

                    }else
                         if (ShotGun1.activeSelf && Input.GetAxis("Mouse ScrollWheel") < 0)
                    {

                        Revolver1.SetActive(true);
                        Revolver2.SetActive(false);
                        ShotGun1.SetActive(false);
                        time = 0;
                        timerControl = false;

                    }else
                        
                         if (ShotGun1.activeSelf && Input.GetAxis("Mouse ScrollWheel") > 0)
                    {

                        Revolver1.SetActive(false);
                        Revolver2.SetActive(true);
                        ShotGun1.SetActive(false);
                        time = 0;
                        timerControl = false;

                    }

                }
                else
                {
                    if (Revolver1.activeSelf)
                    {

                        Revolver1.SetActive(false);
                        Revolver2.SetActive(true);

                        time = 0;
                        timerControl = false;

                    }
                    else
               if (Revolver2.activeSelf)
                    {

                        Revolver2.SetActive(false);
                        Revolver1.SetActive(true);

                        time = 0;
                        timerControl = false;
                    }
                }
            }


        }
        else
        
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                
                   
                    timerControl = true;
              
               
                 
                 



            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
            
           
              
                timerControl = true;



            }
        
    }
}
