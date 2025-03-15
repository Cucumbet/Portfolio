using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController mainplayermovement;
    public Camera mainplayercamera;
    public Vector3 position;
    public Animator walking;
    public float speed;
    private float gravitation = -0.01f;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    private float rotationX = 0;
    public float sensetive = 1;
    public GameObject sword;
    public AudioSource walkingongrass;
    public AudioSource swordattack;
    int count = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         Move();
        rotation();
        //sprint();
        SwordActive();
        SwordSingleAttack();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        
    }

    public void Move()
    {
        ///movement player
        
        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");
        position.x = X;
        position.z = Z;
        position.y = gravitation;
        position = Vector3.ClampMagnitude(position, speed);
        position = transform.TransformDirection(position);
        mainplayermovement.Move(position * speed * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.W))
        {
            walkingongrass.Play();
        }
        if(Input.GetKeyUp(KeyCode.W)) 
        {
        
            walkingongrass.Stop();
        
        }



        if(Z == 0 && X == 0)
        {
            walking.SetBool("Walk", false);


        }


        else 
        {
            walking.SetBool("Walk", true);

        }
        

       
    }


    private void rotation()
    {
        ///movement of mouse
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed * sensetive * 6;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        mainplayercamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed * sensetive * 6, 0);

    }


    //private void sprint()
    //{

    //    if (Input.GetKey(KeyCode.LeftShift))
    //    {

    //        speed = 0.3f ;

    //    }

    //   else
    //    {

    //        speed = 0.2f;

    //    }    
    //}

    public void SwordActive()
    {

        if (Input.GetKeyDown(KeyCode.F))

        {
            count++;
        }

        if (count % 2 == 0)

        {

            walking.SetBool("Swordon", true);
            sword.gameObject.SetActive(true);

        }


        if (count % 2 != 0)

        {

            walking.SetBool("Swordon", false);
            sword.gameObject.SetActive(false);



        }
    }

    public void SwordSingleAttack()
    {

        if (Input.GetMouseButtonDown(0) && sword.gameObject.activeInHierarchy)
        {

            walking.SetTrigger("SingleAttack");
            swordattack.PlayDelayed(0.25f);


        }
        else 
        {
       
        
        }

    }

  
}
