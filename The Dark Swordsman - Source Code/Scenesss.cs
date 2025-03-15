using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenesss : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartLevel1()
    {

        SceneManager.LoadScene("TransitionToNextEtap");


    }

    public void Levelintro()
    {


        SceneManager.LoadScene("TransitionToNextEtap");
    }



    public void Startthegame()
    {

        SceneManager.LoadScene("SampleScene");


    }
}
