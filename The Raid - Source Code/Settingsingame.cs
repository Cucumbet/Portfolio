using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settingsingame : MonoBehaviour
{
    public GameObject Panell;
    public GameObject Settings;
    
    public void Continue()
    {
        Time.timeScale = 1;
        Panell.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    public void Exit()
    {

        SceneManager.LoadScene("Lobby");
        Panell.SetActive(false);
        Time.timeScale = 1;

    }
    public void Setttings()
    {
        Panell.SetActive(false);
        Settings.SetActive(true);

    }

    public void Backk()
    {

        Settings.SetActive(false);
        Panell.SetActive(true);

    }

}
