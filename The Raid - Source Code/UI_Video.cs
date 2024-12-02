using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Video : MonoBehaviour
{
    // Start is called before the first frame update
    public RawImage video;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void StartGame()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("Lobby");
       
        }
        
    }
    void Update()
    {
        StartGame();
    }
}
