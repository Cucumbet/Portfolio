using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyScript : MonoBehaviour
{
    public Button startgame;
    public Button endgame;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ClickBunnton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ClickonExit()
    {

        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 1;
    }
}
