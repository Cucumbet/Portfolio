using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{

    public UiInventoryManager inventoryManager;
    // Start is called before the first frame update
    void Start()
    {
        inventoryManager =  FindAnyObjectByType<UiInventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag == "Player")
        {
          


        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
          
            if(inventoryManager.hpindecator.color.r == 47f / 255f && inventoryManager.hpindecator.color.g == 133f / 255f && inventoryManager.hpindecator.color.b == 0f / 255f)
            {
                
               inventoryManager.hpindecator.color = new Color(236f / 255f, 171f / 255f, 14f / 255f);
            }
               
            else if(inventoryManager.hpindecator.color.r == 236f / 255f && inventoryManager.hpindecator.color.g == 171f / 255f && inventoryManager.hpindecator.color.b == 14f / 255f)
            {

                inventoryManager.hpindecator.color = new Color(117f / 255f, 24f / 255f, 24f / 255f);

            }

            else 
            {

                
                other.gameObject.transform.GetComponent<Animator>().enabled = false;
                other.gameObject.transform.GetComponent<CharacterController>().enabled = false;
                other.gameObject.transform.GetComponent<MovementStateMachine>().enabled = false;
                other.gameObject.transform.GetComponent<RotationStateMachine>().enabled = false;
                other.gameObject.transform.GetComponent<InteractbleStateMachine>().enabled = false;
                other.gameObject.transform.GetComponent<ShootingStateMachine>().enabled = false;
                other.gameObject.transform.GetComponent<CapsuleCollider>().enabled = false;
                inventoryManager.GameOverPanel.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }


        }
    }
}
