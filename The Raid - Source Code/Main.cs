using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEditor.Experimental.GraphView;
using Unity.VisualScripting;

public class Main : MonoBehaviour
{
    [SerializeField] Prisoner boolean; //new
    [SerializeField] public GameObject player; //new
    [SerializeField] List<GameObject> checkPoints;
    [SerializeField] public Vector3 startingPoint;
    [SerializeField] private GameObject _mapIconPass;
    [SerializeField] private GameObject _mapIconKey;
    [SerializeField] private GameObject _mapIconPris1;
    [SerializeField] private GameObject _mapIconPris2;
    [SerializeField] private GameObject _mapIconPris3;
    [SerializeField] private GameObject _mapIconPris4;
    [SerializeField] private GameObject _mapIconPris5;
    [SerializeField] private GameObject _floorText;
    [SerializeField] private GameObject _grFloor;
    [SerializeField] private GameObject _firstFloor;
    [SerializeField] private GameObject _gameWin;
    
    public GameObject Checkpoint;

    public Guard script;
    public GameOver script2;
    public Camera playerCamera;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    private float rotationX = 0;
    public CharacterController Player;
    public Vector3 position;
    private float speed;
    public float startspeed;
    public float minspeed;
    public GameObject Settings;

    private float gravitation = -0.01f;
    Vector2 Rot;
    public float jumpchange;
    public float upp;
    public float downp;
    public iNVENTORY innn;
    public float sensetive = 1;
    public Prisoner prisoner;
    public Text hints;
    public int countPrisoner; //new
    public Text scoree; //new
    public GameObject PAnel;//new
    public AudioSource playersteps; //new
    public AudioClip grass; //new
    public AudioClip metal; //new
    public GameObject keytotransit; //new
    public Image Selftalk; //new
    public Text Selftalking; //new
    public AudioSource music; //new
    public AudioSource radio; //new
 


    public Animator maindoor;
    public Animator lefttomaindoor;
    public Animator righttomaindoor;
    public Animator TransitDoor; //new

    //left to main
    public Animator celldoor1;
    public Animator celldoor2;
    public Animator celldoor3;
    public Animator celldoor4;
    public Animator celldoor5;
    public Animator celldoor6;
    public Animator celldoor7;
    public Animator celldoor8;

    public Animator celldoor1_1;
    public Animator celldoor1_2;
    public Animator celldoor1_3;
    public Animator celldoor1_4;
    public Animator celldoor1_5;
    public Animator celldoor1_6;
    public Animator celldoor1_7;
    public Animator celldoor1_8;

    //right to main
    public Animator celldoor9;
    public Animator celldoor10;
    public Animator celldoor11;
    public Animator celldoor12;
    public Animator celldoor13;


    public Animator celldoor1_9;
    public Animator celldoor1_10;
    public Animator celldoor1_11;
    public Animator celldoor1_12;
    public Animator celldoor1_13;



    //new 2 layer animations
    //left to main
    public Animator celldoor2_1;
    public Animator celldoor2_2;
    public Animator celldoor2_3;
    public Animator celldoor2_4;



    public Animator celldoor22_1;
    public Animator celldoor22_2;
    public Animator celldoor22_3;
    public Animator celldoor22_4;

    //right to main



    public Animator celldoor222_1;
    public Animator celldoor222_2;
    public Animator celldoor222_3;



    public Animator celldoor2222_1;
    public Animator celldoor2222_2;
    public Animator celldoor2222_3;









    private bool isTeleporting = false;
    public KeyCode teleportKey = KeyCode.T;

    // Start is called before the first frame update
    void Start()
    {


        
        speed = startspeed;
        innn = FindAnyObjectByType<iNVENTORY>();
        hints.enabled = true;
        _mapIconKey.SetActive(false);
        _mapIconPris1.SetActive(false);
        _mapIconPris2.SetActive(false);
        _mapIconPris3.SetActive(false);
        _mapIconPris4.SetActive(false);
        _mapIconPris5.SetActive(false);
        _floorText.SetActive(false);
        _grFloor.SetActive(false);
        _firstFloor.SetActive(false);
        _gameWin.SetActive(false);
    }



    int count = 0;
    float t = 0;

    // Update is called once per frame
    private void CreateWay()
    {
        /// prisoner following 1( way )
        if (prisoner != null && Vector3.Distance(this.transform.position, prisoner.transform.position) > 3.5f )
        {

            //Selftalk.enabled = false; //new
            //Selftalking.text = string.Empty; //new
            if (Cango == true)
            {
                if (t > 0.2f)
                {
                    GameObject Sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    Sphere.tag = "Useable";
                    Sphere.GetComponent<MeshRenderer>().enabled = false;
                    Sphere.GetComponent<SphereCollider>().isTrigger = true;
                    Sphere.transform.localScale = Vector3.one / 5;
                    Sphere.transform.position = new Vector3(this.transform.position.x, 1.5f, this.transform.position.z) ;


                    t = 0;
                    prisoner.way.Add(Sphere);
                    Destroy(Sphere, 5);

                }
            }
        }
    }

    public bool Cango;
    void Update()
    {



       lookSpeed = PlayerPrefs.GetFloat("Sensa"); 
        t += Time.deltaTime;
        CreateWay();

        aNimations();
        scoree.text = countPrisoner.ToString() + "/5"; //new
        
       
        
        if(scoree.text == "5/5") //win
        {
           
        _gameWin.SetActive(true);
        if(Input.GetKeyDown(KeyCode.C)){
            SceneManager.LoadScene("Lobby");
            _gameWin.SetActive(false);
        }
        }



 
        if(Input.GetKeyDown(KeyCode.Escape)) //new
        {
          //  Time.timeScale = 0;
            PAnel.SetActive(!PAnel.activeInHierarchy);
            if(PAnel.activeInHierarchy == true)
            {
                Time.timeScale = 0;
                Settings.SetActive(false);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }

            else
            {
                Cursor.lockState= CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
            }
        }


        if (script2.gameIsOver)
        {
            if (Input.GetKeyDown(teleportKey))
            {
                Player.transform.position = startingPoint;
                Player.enabled = true;
                script2.CloseGameOverUI();
            }
        }
        
    }

    
    

    private void OnTriggerEnter(Collider other)
    {
       
        startingPoint = Player.transform.position;
        Destroy(Checkpoint.gameObject);
        
        if(other.transform.tag == "Grass") //new
        {
            playersteps.clip = grass;
            playersteps.enabled = true;
        }
    }



    void FixedUpdate()
    {
        Move();
        rotation();
       
        jump();
        playersteps.volume = PlayerPrefs.GetFloat("Volume");//new
        music.volume = PlayerPrefs.GetFloat("Volume");//new
        radio.volume = PlayerPrefs.GetFloat("Volume");//new

    }



    private void LateUpdate() // new
    {
        Selftallking();

        if ((prisoner.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Laying Idle 1")))
        {
            Selftalk.enabled = true;   //new
            Selftalking.text = "Hurry up, follow me"; //new

        }
        
        if ((prisoner.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Laying Idle 2")))
        {

            Selftalk.enabled = false;   //new
            Selftalking.text = string.Empty; //new
        }



    }
    public void SaveHim()
    {
        prisoner.SitDown.SetTrigger("ReadyToEscape"); //new
        prisoner.SitDown.enabled = true; //new
       
        Cango = true;
        prisoner.dialog.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        sensetive = 3;
        hints.text = "*Get out the prison";

      


    }

    public void Selftallking() //NEW
    {

        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, maindoor.transform.position) < 3 && innn.Active_item == null) //NEW
        {

            Selftalk.enabled = true;
            Selftalking.text = "I need a pass to enter the prison, it's should be on the map (To open the map press M)";


        }

        if (Vector3.Distance(this.transform.position, maindoor.transform.position) > 3 && maindoor.enabled == false)  //NEW
        {
            Selftalk.enabled = false;
            Selftalking.text = string.Empty;

        }



        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, TransitDoor.transform.position) < 3 && innn.Active_item.name != "keytotransit") //NEW
        {

            Selftalk.enabled = true;
            Selftalking.text = "It's locked, I should try to find a key in office rooms";


        }

        if (Vector3.Distance(this.transform.position, TransitDoor.transform.position) > 3 && maindoor.enabled == true )  //NEW
        {
            Selftalk.enabled = false;
            Selftalking.text = string.Empty;

        }
    }

    public void GetAway()
    {


    }
    private void Move()
    {
        ///movement player
        float X = Input.GetAxis("Horizontal");

        float Z = Input.GetAxis("Vertical");
        position.x = X;
        position.z = Z;
        position.y = gravitation;
        position = Vector3.ClampMagnitude(position, speed);
        position = transform.TransformDirection(position);
        Player.Move(position * speed);

        if (Z != 0 || X != 0) //new
        {

            playersteps.enabled = true; //new

        }
        if (X == 0 && Z == 0) //new

        {
            playersteps.enabled = false; //new

        }


        if (script2.gameIsOver)
        {
            Player.enabled = false;
        }
    }
   

    public void OnCollisionEnter(Collision collision) //new
    {
        if (collision.transform.tag == "Prison")

        {
           
            playersteps.clip = metal;
            playersteps.enabled = true;

        }

        if (collision.transform.tag == "Grass")
        {
            
            playersteps.clip = grass;
            playersteps.enabled = true;

        }
        

    }


    private void rotation()
    {
        ///movement of mouse
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed * sensetive * 6;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed * sensetive * 6, 0);

    }

   
    Vector3 jmp;
    private void jump()
    {
        if (Player.isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                jumpchange = upp;
            }
        }
        else
        {
            jumpchange -= downp;
        }
        jmp.y = jumpchange;
        Player.Move(jmp);
    }
    private void aNimations()
    {


        //main enter door
        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, maindoor.transform.position) < 3 && innn.Active_item.name == "Keyy")
        {

            maindoor.enabled = true;
            hints.text = "*explore office rooms/find a key";
            _mapIconKey.SetActive(true);
            _mapIconPass.SetActive(false);


        }



        //bottom doors to main
        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, lefttomaindoor.transform.position) < 2)
        {

            lefttomaindoor.enabled = true;


        }

       
        //transition door
        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, TransitDoor.transform.position) < 3 && innn.Active_item.name == "keytotransit") //new
        {

            TransitDoor.enabled = true;
           
    
             hints.text = "*rescue all prisoners/don't be caught by guard";
            _mapIconKey.SetActive(false);
            _mapIconPris1.SetActive(true);
            _mapIconPris2.SetActive(true);
            _mapIconPris3.SetActive(true);
            _mapIconPris4.SetActive(true);
            _mapIconPris5.SetActive(true);
            _floorText.SetActive(true);
            _grFloor.SetActive(true);
            _firstFloor.SetActive(true);
        }





        //cell doors animations
        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor1.transform.position) < 3)
        {

            celldoor1.enabled = true;


        }

        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor2.transform.position) < 3)
        {

            celldoor2.enabled = true;


        }

        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor3.transform.position) < 3)
        {

            celldoor3.enabled = true;


        }
        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor4.transform.position) < 3)
        {

            celldoor4.enabled = true;


        }
        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor5.transform.position) < 3)
        {

            celldoor5.enabled = true;


        }
        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor6.transform.position) < 3)
        {

            celldoor6.enabled = true;


        }
        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor7.transform.position) < 3)
        {

            celldoor7.enabled = true;


        }
        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor8.transform.position) < 3)
        {

            celldoor8.enabled = true;


        }


        /// OPPOSITE SITE


        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor1_1.transform.position) < 3)
        {

            celldoor1_1.enabled = true;


        }
        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor1_2.transform.position) < 3)
        {

            celldoor1_2.enabled = true;


        }

        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor1_3.transform.position) < 3)
        {

            celldoor1_3.enabled = true;


        }


        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor1_4.transform.position) < 3)
        {

            celldoor1_4.enabled = true;


        }

        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor1_5.transform.position) < 3)
        {

            celldoor1_5.enabled = true;


        }

        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor1_6.transform.position) < 3)
        {

            celldoor1_6.enabled = true;


        }

        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor1_7.transform.position) < 3)
        {

            celldoor1_7.enabled = true;


        }

        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor1_8.transform.position) < 3)
        {

            celldoor1_8.enabled = true;


        }


        //Second block

        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor9.transform.position) < 3)
        {

            celldoor9.enabled = true;


        }

        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor10.transform.position) < 3)
        {

            celldoor10.enabled = true;


        }

        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor11.transform.position) < 3)
        {

            celldoor11.enabled = true;


        }


        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor12.transform.position) < 3)
        {

            celldoor12.enabled = true;


        }

        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor13.transform.position) < 3)
        {

            celldoor13.enabled = true;


        }


        //Opposite site 2ndblock


        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor1_9.transform.position) < 3)
        {

            celldoor1_9.enabled = true;


        }

        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor1_10.transform.position) < 3)
        {

            celldoor1_10.enabled = true;


        }


        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor1_11.transform.position) < 3)
        {

            celldoor1_11.enabled = true;


        }


        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor1_12.transform.position) < 3)
        {

            celldoor1_12.enabled = true;


        }


        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor1_13.transform.position) < 3)
        {

            celldoor1_13.enabled = true;


        }



        //second layer
        //left to main

        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor2_1.transform.position) < 3)
        {

            celldoor2_1.enabled = true;


        }

        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor2_2.transform.position) < 3)
        {

            celldoor2_2.enabled = true;


        }


        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor2_3.transform.position) < 3)
        {

            celldoor2_3.enabled = true;


        }


        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor2_4.transform.position) < 3)
        {

            celldoor2_4.enabled = true;


        }

        //opposite

        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor22_1.transform.position) < 3)
        {

            celldoor22_1.enabled = true;


        }

        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor22_2.transform.position) < 3)
        {

            celldoor22_2.enabled = true;


        }


        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor22_3.transform.position) < 3)
        {

            celldoor22_3.enabled = true;


        }


        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor22_4.transform.position) < 3)
        {

            celldoor22_4.enabled = true;


        }


        //right to main

        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor222_1.transform.position) < 3)
        {

            celldoor222_1.enabled = true;


        }

        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor222_2.transform.position) < 3)
        {

            celldoor222_2.enabled = true;


        }


        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor222_3.transform.position) < 3)
        {

            celldoor222_3.enabled = true;


        }

        //opposite

        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor2222_1.transform.position) < 3)
        {

            celldoor2222_1.enabled = true;


        }

        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor2222_2.transform.position) < 3)
        {

            celldoor2222_2.enabled = true;


        }


        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(this.transform.position, celldoor2222_3.transform.position) < 3)
        {

            celldoor2222_3.enabled = true;


        }
    }
}

