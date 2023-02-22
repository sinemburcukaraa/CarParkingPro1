using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionArrow : MonoBehaviour
{
    public Transform target;
    void Update()
    {
        if (target)
        {
            Vector3 TargetPos = target.transform.position;
            TargetPos.y = transform.position.y;
            this.transform.LookAt(TargetPos);
        }
   
    }
}
