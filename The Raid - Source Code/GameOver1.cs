using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver1 : MonoBehaviour
{

    public Image gameover;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Tryagain()
    {

        SceneManager.LoadSceneAsync("Game");

    }


    public void Menu()
    {

        SceneManager.LoadSceneAsync("Lobby");
    }
}
