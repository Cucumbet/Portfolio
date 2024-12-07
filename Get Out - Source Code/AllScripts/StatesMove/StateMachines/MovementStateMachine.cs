using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;



public class MovementStateMachine : StateMachine
{
    public IdleState idleState { get; protected set; }
    public WalkState walkState { get; protected set; }
        
    public HorizontalMovement horizmove { get; protected set; }
    public RunState runState { get; protected set; }
    public RayCastt pickray;




    public static string CanRun => "CanRun";

  


    Vector3 position;
    private float gravitation = -0.1f;
    public float speed = 0.08f;
    private CharacterController characterController;
    public UiInventoryManager inventoryManager;
    private Animator animator;
    public Animator Animator => animator;

    // Start is called before the first frame update


    private void Awake()
    {
        animator = GetComponent<Animator>();
        idleState = new IdleState(this);
        walkState = new WalkState(this);
        runState = new RunState(this);
        horizmove = new HorizontalMovement(this);



        characterController = GetComponent<CharacterController>();
    }
    protected override BaseState GetInitialState()
    {
        return idleState;
    }


    public void Move()
    {
    
        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");
        position.x = X;
        position.z = Z;
        position.y = gravitation;
        position = Vector3.ClampMagnitude(position, speed);
        position.x = 0;
        position = this.transform.TransformDirection(position);
        this.characterController.Move(position * speed);
        animator.SetFloat("Vertical", Z);
        animator.SetFloat("Horizontal", X);
    }



    public void HorizontalMove()
    {

        float X = Input.GetAxis("Horizontal");
        position.x = X;
        position.y = gravitation;
        position = Vector3.ClampMagnitude(position, speed);
        position = this.transform.TransformDirection(position);
        this.characterController.Move(position * (speed * 3));
        animator.SetFloat("Horizontal", X);
    }
    //public void MoveRight() 
    //{
    //    float X = Input.GetAxis("Horizontal");
    //    position.z = X;
    //    position.y = gravitation;
    //    position = Vector3.ClampMagnitude(position, speed);
    //    position = this.transform.TransformDirection(position);
    //    this.characterController.Move(position * speed);
    //    animator.SetFloat("Vertical", X);
    //    animator.SetFloat("Horizontal", 0);
    //}

    //public void MakeAnimWalk ()
    //{

    //    animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
    //    animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

    //}
    public void Setbool(string param, bool value)
    {
        animator.SetBool(param, value);

    }

    //public void Setfloat(string parama, float valuee)
    //{
    //    animator.SetFloat(parama, valuee);
    
    //}
    public void Transitor()
    {
        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");
        position.x = X;
        position.z = Z;
        position.y = gravitation;
        position = Vector3.ClampMagnitude(position, speed);
        position.x = 0;
        position = this.transform.TransformDirection(position);
        this.characterController.Move(position * speed * 1.2f);
        
       
    }


    private void OnTriggerExit(Collider other)
    {
       if(other.transform.tag == "GameWon")
        {
  
            inventoryManager.GameWonPanel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;


        }


    }


}
