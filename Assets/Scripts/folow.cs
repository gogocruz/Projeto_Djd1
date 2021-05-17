using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class folow : MonoBehaviour
{
    [SerializeField] Transform followTarget;
    [SerializeField] float      followSpeed = 0.1f;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 currentPos = transform.position;

        if (followTarget != null)
        {
            Vector3 targetPos = followTarget.position;



            Vector3 error = targetPos - currentPos;

            targetPos = currentPos + error * followSpeed;
            currentPos = new Vector3(targetPos.x, targetPos.y, currentPos.z);

            currentPos.y += 12;
        }
        

        transform.position = currentPos;
    }
}
