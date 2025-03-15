using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Fireeeee : MonoBehaviour
{
    public ParticleSystem fire;
   public List<GameObject> gameObjects = new List<GameObject>();
    public AudioSource soundoffire;
    public List<Vector3> points = new List<Vector3>();
    public GameObject rock1;
    public XRGrabInteractable fishones;
    public Material fishcolar;
    public XRBaseInteractable[] woodsticks;
    public bool fishiscooked;
    float x = 0;
    public AudioSource audioSource;
    private bool hasPlayedSound = false;

    // Start is called before the first frame update
    void Start()
    {
        if (audioSource == null) //not my
        {
            GameObject audioObject = GameObject.Find("VoiceOver4");
            if (audioObject != null)
            {
                audioSource = audioObject.GetComponent<AudioSource>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObjects.Count == 4)
        {
            if (!hasPlayedSound) // not my
            {
                audioSource.Play();
                hasPlayedSound = true; // Prevents sound from playing multiple times
            }
        }      
    }

    private void OnTriggerEnter(Collider other)
    {
      
     
        

        if (other.transform.tag == "Stonelight" && gameObjects.Count == 4)
        {

            fire.Play();
            soundoffire.Play();
            fishcolar.EnableKeyword("_EMISSION");
            fishcolar.color = new Color(1, 0, 0);
            fishones.enabled = true;
            fishiscooked = true;
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
        if (other.transform.tag == "wood" )
        {

            other.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            other.gameObject.transform.localPosition = Vector3.zero;
            gameObjects.Add(other.gameObject);
            gameObjects[gameObjects.Count - 1].transform.localRotation = Quaternion.Euler(x, 0, 0);
            gameObjects[gameObjects.Count - 1].transform.localRotation = Quaternion.Euler(points[gameObjects.Count - 1]);

           

        }

        if(other.transform.tag == "Fish" && fishcolar.color == new Color(1, 1, 1))
        {
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            Vector3 pos = rock1.transform.position;
            pos.y = -0.6406f;
            other.gameObject.transform.position = pos;
            fishones.enabled = false;


            

        }




    }


}
