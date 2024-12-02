using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Menu : MonoBehaviour
{
    public Image lobby;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void Exit()
    {

        Application.Quit();

    }
    public void OpenGame()
    {
        
        SceneManager.LoadSceneAsync("Game");
    }

    public void Setings()
    {
        SceneManager.LoadScene("Settings");


    }

    //settings
    public void Back()
    {

        SceneManager.LoadScene("Lobby");

    }
    void Update()
    {
        LightProbes.Tetrahedralize();
    }


}
