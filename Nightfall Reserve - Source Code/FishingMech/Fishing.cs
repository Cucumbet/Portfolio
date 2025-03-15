using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    public Transform rodTip;
    public Transform hookTarget;
    public LineRenderer lineRenderer;
    public SpringJoint springJoint;
    public float maxLineLength = 0.00001f;


    private Rigidbody hookRb;

    void Start()
    {

        hookRb = hookTarget.GetComponent<Rigidbody>();
        if (hookRb == null)
        {
            hookRb = hookTarget.gameObject.AddComponent<Rigidbody>();
        }

        springJoint = hookTarget.gameObject.AddComponent<SpringJoint>();
        springJoint.connectedBody = null;
        springJoint.spring = 50;
        springJoint.damper = 5;
        springJoint.maxDistance = maxLineLength;
    }
 void Update()
 {
    
     if (lineRenderer != null)
     {
         lineRenderer.SetPosition(0, rodTip.position); 
         lineRenderer.SetPosition(1, hookTarget.position); 
     }

     float distance = Vector3.Distance(rodTip.position, hookTarget.position);


 
        //if (distance > maxLineLength)
        //{
        //    springJoint.maxDistance = distance; 
        //}
        //else
        //{
        //    springJoint.maxDistance = maxLineLength;
        //}
    }


    private void FixedUpdate()
    {
        Vector3 targetPos = rodTip.position + (hookTarget.position - rodTip.position).normalized * maxLineLength;
        hookRb.MovePosition(targetPos);
    }
}
