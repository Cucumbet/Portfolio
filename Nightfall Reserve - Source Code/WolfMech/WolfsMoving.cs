using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfsMoving : MonoBehaviour
{  
   
    
    public GameObject TargetToAttack;
    private NavMeshAgent Agent;
    Vector3 startPosition;
    bool isWalk = true;
    Vector3 targetpos;
    public Spawner spawner;
    // Start is called before the first frame update
   
    void Start()
    {
         Agent = GetComponent<NavMeshAgent>();
        startPosition = transform.position;
    }

    public void Back()
    {
        isWalk = false;

    }
    private void Sprint()
    {

        if (Vector3.Distance(this.transform.position, TargetToAttack.transform.position) < 6)
        {

            Agent.speed = 8;

        }
        else 
        {
            Agent.speed = 3;
        }

    }
    // Update is called once per frame
    void Update()
    {
        Sprint();
      if(isWalk)
        {
            targetpos = TargetToAttack.transform.position;
        }
        else
        {
            targetpos = startPosition;
            
        }
        Agent.SetDestination(targetpos);

        if(Vector3.Distance(this.transform.position, startPosition ) < 2 && isWalk == false) 
        {
          Destroy(this.gameObject);   
            spawner.RemoveWolf(this.gameObject);
        }
    }
}
