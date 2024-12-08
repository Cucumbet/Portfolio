using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class ShootingStateMachine : StateMachine
{
    public ShootingState shoot { get; protected set; }
    public Camera cameraplayer;
    public GameObject bullets;
    private Animator animator;
    public TextMeshProUGUI currentbullets; //10
    public TextMeshProUGUI overallbullets; //0-40
    public int maxAmmo = 10;
    public int totalammo;
    public int ammoneeded;
    public int ammotoreload;
    public int currentammo;

    public Animator Animator => animator;

    protected override BaseState GetInitialState()
    {
        return shoot;
    }

  
    private void Awake()
    {
        shoot = new ShootingState(this);
        animator = GetComponent<Animator>();
    }

    public void Shoot()
    {

        if(this.animator.GetBool("PistolOn") == true )
        {
            
            currentammo -= 1;
            GameObject clone = Instantiate(bullets);
            clone.gameObject.SetActive(true);
            clone.transform.SetParent(bullets.transform);
            clone.transform.localPosition = Vector3.zero;
            clone.transform.localScale = new Vector3(1, 1, 1);
            clone.transform.SetParent(null);
            clone.GetComponent<Rigidbody>().AddForce(transform.forward * 1, ForceMode.Impulse);
            


            if (Physics.Raycast(cameraplayer.transform.position, cameraplayer.transform.forward, out RaycastHit hitInfo, 10))
            {
                //GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = hitInfo.point;
                if (hitInfo.transform.name == "mixamorig5:Head")
                {
                    hitInfo.transform.GetComponent<Rigidbody>().isKinematic = false;
                    hitInfo.transform.GetComponent<Rigidbody>().AddForce((hitInfo.point - this.transform.position).normalized * 50, ForceMode.Impulse);
                    hitInfo.transform.GetComponentInParent<ZombieA>().zombiedie();
                    hitInfo.transform.GetComponentInParent<Animator>().enabled = false;
                    hitInfo.transform.GetComponentInParent<NavMeshAgent>().enabled = false;
                    hitInfo.transform.GetComponentInParent<ZombieA>().enabled = false;
                    hitInfo.transform.GetComponentInParent<CapsuleCollider>().enabled = false;
                }

                if (hitInfo.transform.tag == "Zombieparts")
                {
                    hitInfo.transform.GetComponentInParent<ZombieA>().counthit++;

                    if (hitInfo.transform.GetComponentInParent<ZombieA>().counthit == 4)
                    {

                        // hitInfo.transform.GetComponent<Rigidbody>().AddForce((hitInfo.point - this.transform.position).normalized * 10, ForceMode.Impulse);
                        hitInfo.transform.GetComponent<ZombieA>().zombiedie();
                        hitInfo.transform.GetComponent<Animator>().enabled = false;
                        hitInfo.transform.GetComponent<NavMeshAgent>().enabled = false;
                        hitInfo.transform.GetComponent<ZombieA>().enabled = false;
                        hitInfo.transform.GetComponent<CapsuleCollider>().enabled = false;
                    }
                }
            }
        }
  

        
    }

}
