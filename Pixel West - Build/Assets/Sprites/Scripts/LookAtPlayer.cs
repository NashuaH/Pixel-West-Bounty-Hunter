using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float distToRotate;

    void Update()
    {
        float dist = Vector3.Distance(target.position, transform.position);

        if (dist > distToRotate)
        {
            Vector3 TargetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

            transform.LookAt(TargetPosition);
        }
    }

}
