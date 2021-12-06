using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public PlayerMovement MoveScript;
    public MouseLook MouseScript;
    public Interaction IntScript;
    // Start is called before the first frame update
    void Start()
    {
        MoveScript = GetComponent<PlayerMovement>();
        MouseScript = GetComponent<MouseLook>();
        IntScript = GetComponent<Interaction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IntScript.Interacting)
        {
            MoveScript.enabled = false;
            MouseScript.enabled = false;
        }
      
    }
}
