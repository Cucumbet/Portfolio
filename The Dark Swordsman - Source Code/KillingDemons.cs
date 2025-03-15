using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillingDemons : MonoBehaviour
{
    public Demons realones;
    Transform particle;
    public AudioSource realonesound;
    public AudioSource fakesound;
    public int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Demon")
        {


            particle = other.gameObject.transform.parent.GetChild(33);
            
            particle.transform.parent = null;
            particle.gameObject.SetActive(true);
            Destroy(other.gameObject.transform.parent.gameObject);




        }
        

        if(other.gameObject.tag == "Demon" && particle.transform.gameObject.tag == "Realone")
        {

            count++;
            /// sound of real
            realonesound.Play();

        }


        if (other.gameObject.tag == "Demon" && particle.transform.gameObject.tag == "Fakeone")
        {

            
            /// sound of real
            fakesound.Play();

        }




        if (count == 7) 
        
        {

            SceneManager.LoadScene("LevelIntro");
        
        
        }
    }






}
