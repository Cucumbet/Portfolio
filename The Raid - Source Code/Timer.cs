using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    //new
    public Text timerr;
    float hours = 17;
    float minutes = 45;
    float seconds = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (minutes != 30)
        {
            seconds += Time.deltaTime;
            if (seconds > 20)
            {
                seconds = 0;
                minutes++;
            }


            if (minutes > 59)
            {
                minutes = 0;
                hours++;

            }
            if (minutes <= 9)
            {
                timerr.text = hours.ToString() + ":0" + minutes.ToString();

            }
            else
            {
                timerr.text = hours.ToString() + ":" + minutes.ToString();
            }

        }

        if(minutes == 30)
        {

            SceneManager.LoadSceneAsync("GameOver"); //lose

        }
    }
}
