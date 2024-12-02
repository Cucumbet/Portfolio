using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Prisoner : MonoBehaviour
{

    public List<GameObject> way = new List<GameObject>();
    public Main player;
    public GameObject dialog;
    int ind = 0;
    public Animator SitDown;

    void Start()
    {

    }
    
    private float FFF(Vector3 a, Vector3 b) ///prisoner follows moving
    {
        return Mathf.Sqrt((a.x - b.x) * (a.x - b.x) + (a.z - b.z) * (a.z - b.z));

    }
    Vector3 prevPos;
    // Update is called once per frame
    void LateUpdate()
    {
        ///prisoner follows
        ///
        if(Vector3.Distance(prevPos,this.transform.position) == 0)
        {
            
        }
        if(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Laying Idle 2"))  //new
        {
            Vector3 p = this.transform.position;
            p.y = 1.5f;
            this.transform.position = p;
        }


        
        Quaternion LookToPlayer = Quaternion.LookRotation(player.transform.position - this.transform.position); //new
        float dist = Vector3.Distance(this.transform.position, player.transform.position);
        if (way.Count > 0 && ind < way.Count) //new
        {
           
            LookToPlayer = new Quaternion(0, LookToPlayer.y, 0, LookToPlayer.w); //new
            this.transform.rotation = LookToPlayer; //new
            if (dist < 3) //new
            {
                SitDown.SetBool("RunStand", false);
                Vector3 rot = this.transform.eulerAngles;
                rot.y += 75;
                this.transform.eulerAngles = rot;
               
                //  this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + 0.07f, this.transform.position.z);

            }
            else
            {
                SitDown.SetBool("RunStand", true);
             
            }
            if (way[ind] != null && FFF(transform.position, way[ind].transform.position) < 2)
            {
              
                way.RemoveAt(ind);
                ind++;
                //SitDown.SetTrigger("StandUp"); //new
                //SitDown.SetTrigger("ReadyToEscape"); //new
               // SitDown.SetBool("RunStand", false); //new
            }
            else
            {
                //SitDown.SetTrigger("StandUp"); //new
                //SitDown.SetTrigger("ReadyToEscape"); //new
               //new
                Vector3 pos = way[ind].transform.position;
               // pos.y += transform.localScale.y * 2;
                
               Vector3 newpos  = Vector3.MoveTowards(transform.position, pos, 0.12f);
                //newpos.y += 0.009f;
                //  newpos.y = 0.3f;
                //   this.transform.position = newpos;
                GetComponent<Rigidbody>().position = newpos;
                //Vector3 p = this.transform.position;
                //p.y = 1.5f;
                //this.transform.position = p;
                //  transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.03f);
            }
        }



      prevPos = this.transform.position;

        //if(dist > 5 && isClicked )
        //{
        //    SitDown.SetTrigger("StandUp"); //new
        //    SitDown.SetTrigger("ReadyToEscape"); //new
        //    SitDown.SetBool("Run/Stand", true); //new
        //    transform.position = Vector3.Slerp(transform.position, player.transform.position,1f);
        //    print(transform.position);
        //}
        //if(dist < 2 && isClicked)
        //{
        //    SitDown.SetTrigger("StandUp"); //new
        //    SitDown.SetTrigger("ReadyToEscape"); //new
        //    SitDown.SetBool("Run/Stand", false); //new
    //   }
        if (dist < 2 && Input.GetKeyDown(KeyCode.F))
        {
            player.prisoner = this; //new
            SitDown.SetTrigger("StandUp"); //new
            isClicked = true;   
            Cursor.visible = true;
            dialog.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            player.sensetive = 0;
        }
    }
    bool isClicked;
    public void StopAnin()
    {
        SitDown.enabled = false;   //new
    }

    private void OnTriggerEnter(Collider other)  //new
    {
        
        if (other.gameObject.tag == "Prisoners")
        {
            
            player.countPrisoner++;
            Destroy(this.gameObject);
           
            
        }
    
    }
}
