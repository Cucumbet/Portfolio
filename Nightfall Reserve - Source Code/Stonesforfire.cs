using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Stonesforfire : MonoBehaviour
{
    // Start is called before the first frame update

    public ParticleSystem stones;
    [SerializeField] XRGrabInteractable pickup;

    void Start()
    {
        pickup = gameObject.GetComponent<XRGrabInteractable>();
        pickup.selectEntered.AddListener(obGrab);

    }
    public void obGrab(SelectEnterEventArgs obj)
    {
     
        
    
    
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {

        stones.Play();

    }
}
