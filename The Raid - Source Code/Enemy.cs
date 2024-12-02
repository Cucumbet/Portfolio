using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public Main player;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    bool IsLockHim = false;

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(this.transform.position, player.transform.position); 
        if ( dist < 5  && IsLockHim == false)
        {
            Cursor.visible = true;
            panel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            player.sensetive = 0;
        }
        
        
     
    }
    public void ShootHim()
    {
        SceneManager.LoadScene("Lobby");


    }

    public void LockHim() 
    {
        IsLockHim = true;
        Cursor.visible = false;
        panel.SetActive(false);
        player.sensetive = 3;
        Cursor.lockState = CursorLockMode.Locked;
        //this.transform.rotation = Quaternion.Euler(90, 0, 0); 

    }
}
