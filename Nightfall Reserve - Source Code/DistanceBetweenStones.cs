using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class DistanceBetweenStones : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] XRGrabInteractable interactable;
    [SerializeField] XRGrabInteractable interactable1;
    [SerializeField] GameObject InvisibleObject;

    private bool interactablee;
    private bool interactablee2;
    private float Distance;
    private float time;

    void Start()
    {
        interactable.selectEntered.AddListener(obGrab);
        interactable1.selectEntered.AddListener(obeGrab);


        interactable.selectExited.AddListener(obdown);
        interactable1.selectExited.AddListener(obedown);
    }
    public void obGrab(SelectEnterEventArgs obj)
    {

        interactablee = true;

    }

    public void obeGrab(SelectEnterEventArgs obj)
    {


        interactablee2 = true;


    }


    public void obdown(SelectExitEventArgs obj)
    {

        interactablee = false;

    }

    public void obedown(SelectExitEventArgs obj)
    {


        interactablee2 = false;


    }
    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;
        if (interactablee == true && interactablee2 == true)
        {

            if(Distance <= 0.05f && time > 2)
            {

                interactable.GetComponent<Stonesforfire>().stones.Play();
                interactable1.GetComponent<Stonesforfire>().stones.Play();
                time = 0;
                GameObject.Instantiate(InvisibleObject, this.transform.position, Quaternion.identity);
            }


            Distance = Vector3.Distance(interactable.transform.position, interactable1.transform.position);
            
        }


    }
}
