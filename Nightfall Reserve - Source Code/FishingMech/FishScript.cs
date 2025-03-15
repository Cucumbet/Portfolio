using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class FishScript : MonoBehaviour
{
    public XRGrabInteractable interact;
    public XRGrabInteractable interactdown;
    public Rigidbody fishie;
    public GameObject SpawPoint;
    public GameObject TargetPos;
    float t = 0;
    public HookScript sss;
    public Fireeeee firescript;
    public AudioSource audioSource; //nm
    public AudioSource audioSource2;//nm
    private bool hasPlayedSound = false;//nm
    private bool hasPlayedSound2 = false;//nm

    void Start()
    {
        interact.selectEntered.AddListener(obGrab);
        interactdown.selectExited.AddListener(obedown);

        if (audioSource == null) // not my
        {
            GameObject audioObject = GameObject.Find("VoiceOver3");
            if (audioObject != null)
            {
                audioSource = audioObject.GetComponent<AudioSource>();
            }
        }

        if (audioSource2 == null) // not my
        {
            GameObject audioObject = GameObject.Find("VoiceOver5");
            if (audioObject != null)
            {
                audioSource2 = audioObject.GetComponent<AudioSource>();
            }
        }

    }
    public void obGrab(SelectEnterEventArgs obj) //picked up
    {
       

        sss.hokey = false;

        if (!hasPlayedSound) //not my
        {
            audioSource.Play();
            hasPlayedSound = true; // Prevents sound from playing multiple times
        }
    }
    public void obedown(SelectExitEventArgs obj) //dropped
    {
        this.fishie.isKinematic = false;
        sss.hokey = false;
  

    }
    float prevT;
   public  bool fishk = true;
    private void LateUpdate()
    {

        
        if (fishk == true)
        {
            FishMoving();

        }




    }
    // Update is called once per frame
    void Update()
    {
        if(firescript.fishiscooked == true && interact.isSelected && Input.GetAxis("XRI_Right_Trigger") > 0)
        {
            if (!hasPlayedSound2)// not my
                {
                    audioSource2.Play(); 
                    hasPlayedSound2 = true; // Prevents sound from playing multiple times
                }
           this.gameObject.SetActive(false);

        }
    }

    public void FishMoving ()
    {

        t += 0.0009f;
  

        float t2 = Mathf.PingPong(t, 1);
        if (t2 > prevT)

        {
            this.transform.rotation = Quaternion.Euler(180, -90, 90);

        }

        if (t2 < prevT)
        {

            this.transform.rotation = Quaternion.Euler(180, 90, 90);
        }
        this.transform.position = Vector3.Lerp(SpawPoint.transform.position, TargetPos.transform.position, t2);

        prevT = t2;


    }

  
    
}
