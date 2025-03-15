using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TextChanging : MonoBehaviour
{

    public string answer;
    public List<string> answersforthistag = new();
    public TextMeshProUGUI thistagtext;
    public AnswersRandomizer randomizer;
    int index;

    bool checkammount = false;


    // Start is called before the first frame update

    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {

        if (randomizer.buttons.Count(x => x.transform.GetChild(1).gameObject.activeInHierarchy) > 0)
        {
            checkammount = true;
        }
            thistagtext.text = answersforthistag[index]; 
    }

    public void TextChangeng()
    {

        if (checkammount)
        {
            index++;
            checkammount = false;
        }

    }

    public void PreviousAnswers()
    {
        //if(!checkammount && ) 

        //{ 
        
            index--;
            


        //}



    }

}
