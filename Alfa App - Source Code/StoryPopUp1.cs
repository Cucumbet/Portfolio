using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryPopUp1 : MonoBehaviour
{


    public void Next()
    {

        SceneManager.LoadScene("ChooseGame");
    }




    public void Programminigame()
    {

        SceneManager.LoadScene("ProgramingMiniGame");


    }



    public void Designminigame()
    {

        SceneManager.LoadScene("ArtMini");


    }


    public void HomePage()
    {

        SceneManager.LoadScene("HomePage");

    }
}
