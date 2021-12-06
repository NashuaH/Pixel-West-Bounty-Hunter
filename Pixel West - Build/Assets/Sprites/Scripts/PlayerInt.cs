using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInt : MonoBehaviour
{
    public PlayerMovement MoveScript;
    public Transform target;
    public Interaction IntScript;
    
    // Start is called before the first frame update
    void Start()
    {
        MoveScript = GetComponent<PlayerMovement>();
       
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveScript.enabled = true;
        if (IntScript.Interacting)
        {
            MoveScript.enabled = false;
            Vector3 TargetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

            transform.LookAt(TargetPosition);
        }

    }
}
