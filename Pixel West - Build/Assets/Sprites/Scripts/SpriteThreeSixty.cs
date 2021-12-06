using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteThreeSixty : MonoBehaviour
{
    public Transform target;
    public GameObject player;
    public bool right;

    public GameObject Front;
    public GameObject Back;
    public GameObject Left;
    public GameObject Right;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
    }
    void Update()
    {
       
        Vector3 targetDir = target.position - transform.position;
        Vector3 forward = transform.forward;
        float angle = Vector3.Angle(targetDir, forward);
        if (Vector3.Angle(target.right, target.position - target.position) > 90f) right = false; else right = true;

       
        if (angle < 45.0f )
        {
            Back.SetActive(false);
            Front.SetActive(true);
            Left.SetActive(false);
            Right.SetActive(false);
        }
        if (angle >120.0f)
        {
            Back.SetActive(true);
            Front.SetActive(false);
            Left.SetActive(false);
            Right.SetActive(false);
        }
        if (angle > 45.0f && angle < 120.0f)
        {
            Back.SetActive(false);
            Front.SetActive(false);
            Left.SetActive(true);
            Right.SetActive(false);
        }
      
    }
}
