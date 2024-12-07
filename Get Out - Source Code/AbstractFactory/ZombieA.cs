using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ZombieA : MonoBehaviour, IZombie
{
    private NavMeshAgent zombiewalk;
    public MovementStateMachine player;
    public Animator animator;

    public Rigidbody[] parts;
    public int counthit;

    public void Awake()
    {
        parts = GetComponentsInChildren<Rigidbody>();
        foreach (var part in parts)
        {
            part.isKinematic = true;
        }
    }
    public void Start()
    {
        zombiewalk = GetComponent<NavMeshAgent>();
        player = FindAnyObjectByType<MovementStateMachine>();
        animator = GetComponent<Animator>();
   
    }
    public void Walk()
    {

        zombiewalk.SetDestination(player.transform.position);
       
        if (Vector3.Distance(player.transform.position, zombiewalk.transform.position) < 3)
        {

            zombiewalk.speed = 3;


        }
        else
        {

            zombiewalk.speed = 1;
        }


    }

    public void Attack()
    {



       if(Vector3.Distance(player.transform.position, zombiewalk.transform.position) < 2)
        {
           
            animator.SetBool("Attack", true);


        }

       else
        {
            animator.SetBool("Attack", false);
            
        }
    }



    public void zombiedie()
    {
        foreach (var part in parts)
        {
            part.isKinematic = false;
        }

    }

    public void Update()
    {
        
        Walk();
        Attack();
    }
}
