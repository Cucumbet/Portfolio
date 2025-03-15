using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactors.Visuals;

public class DoorOpening : MonoBehaviour
{
    public Animator button;
    public Animator fencedoor;
    public AudioSource audioSource;
    private bool hasPlayedSound = false;
    // Start is called before the first frame update
    void Start()
    {
        if (audioSource == null)
        {
            GameObject audioObject = GameObject.Find("VoiceOver2");
            if (audioObject != null)
            {
                audioSource = audioObject.GetComponent<AudioSource>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(Physics.Raycast(transform.position,transform.forward,out RaycastHit hit,10))
        {
            if (Input.GetAxis("XRI_Right_Trigger") > 0 && hit.transform.tag == "button")
            {

                button.enabled = true;

            }
        }

        if(button.enabled == true) 
        {
           fencedoor.enabled = true;

            if (!hasPlayedSound)
            {
                audioSource.Play();
                hasPlayedSound = true; // Prevents sound from playing multiple times
            }
        }
    
    }




}
