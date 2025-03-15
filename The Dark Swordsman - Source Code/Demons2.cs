using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Demons2 : MonoBehaviour
{
    public NavMeshAgent demons;
    public GameObject player;
    public GameObject bridge;
    public GameObject Checkpoint;
    public TextMeshProUGUI mousepress;
    public AudioSource bridgefall;
    public Movement1 movement1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = player.transform.position;
        pos.x = 190;
        demons.SetDestination(pos);
        stopp();
    }


    public void stopp()
    {
        Vector3.Distance(Checkpoint.transform.position, player.transform.position);


        if (Vector3.Distance(Checkpoint.transform.position, player.transform.position) <= 20 )
        {

            mousepress.enabled = true;

        }

        if (Vector3.Distance(Checkpoint.transform.position, player.transform.position) <= 5 && Input.GetMouseButtonDown(0))
        {
            bridge.SetActive(false);
            demons.gameObject.SetActive(false);
            mousepress.enabled = false;
            bridgefall.enabled = true;
            movement1.Music.enabled = false;
            movement1.Tired.enabled = true;
            movement1.speed = 5;
            movement1.getinhouse.enabled = true;
        }




    }

    public void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.transform.tag == "Player") 
        {

            SceneManager.LoadScene("DieLevel1.1");
        
        
        }

        
    }
    

      

    
}
