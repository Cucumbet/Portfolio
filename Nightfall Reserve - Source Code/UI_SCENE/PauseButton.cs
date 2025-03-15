using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public GameObject panelMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clickpause()
    {
        Time.timeScale = 0;
        panelMenu.SetActive(true);
    }

    public void ClickonLobby()
    {
        SceneManager.LoadScene("StartScene'");

    }

    public void ClickonContinue()
    {
        Time.timeScale = 1;
        panelMenu.SetActive(false);
    }



}
