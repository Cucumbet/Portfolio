using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement1 : MonoBehaviour
{
    public CharacterController mainplayermovement;
    public Camera mainplayercamera;
    public Vector3 position;
    public Animator walking;
    public float speed;
    private float gravitation = -9;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    private float rotationX = 0;
    public float sensetive = 1;
    public GameObject sword;
    public AudioSource walkingongrass;
    public GameObject tree;
    public TextMeshProUGUI textspace;
    int count = 1;
    public AudioSource Music;
    public AudioSource Tired;

    public GameObject house;
    public TextMeshProUGUI getinhouse;
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
        Obstacels();
        Getinhouse();
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
            


        }
        else 
        {
       
        
        }

    }

    public void Obstacels()
    {

        Vector3.Distance(tree.transform.position, this.transform.position);

        if (Vector3.Distance(tree.transform.position, this.transform.position) <= 10)
        {

            textspace.enabled = true;



        }


        if (Vector3.Distance(tree.transform.position, this.transform.position) <= 7 && Input.GetKeyDown(KeyCode.Space))
        {
            
            gravitation = 0;
            walking.SetBool("JumpOver", true) ;
            


        }





    }

   public void Grav()
    {
        textspace.enabled = false;
        walking.SetBool("JumpOver", false) ;
       
        gravitation = -9;
      

    }


   
    public void Getinhouse()
    {

        Vector3.Distance(house.transform.position, this.transform.position);

        if(Vector3.Distance(house.transform.position, this.transform.position) <= 20)
        {


            SceneManager.LoadScene("Ending");

        }

    }

}
