using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Player : MonoBehaviour
{
    public InputDevice id;
    public Object animalscare;
   
    public XRGrabInteractable interactable;
    public Spawner spawner;
    public AudioSource airhorn;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

        foreach (var item in spawner.Wolfs)
        {
          
            if(Vector3.Distance(item.transform.position,this.transform.position) < 6)
            {
            
               if (interactable.isSelected && Input.GetAxis("XRI_Right_Trigger") > 0)
                {
                   
                    item.GetComponent<WolfsMoving>().Back();
                    
                }
            
               
            }

        }
        //Ray r = new Ray(Head.transform.position,Head.transform.forward);
        // if(Physics.Raycast(r,out RaycastHit hitobj,2))
        // {
        //     print(hitobj.collider.name);
        // }

        if (interactable.isSelected && Input.GetAxis("XRI_Right_Trigger") > 0)
        {
            airhorn.Play();
           

        }
    }
}
