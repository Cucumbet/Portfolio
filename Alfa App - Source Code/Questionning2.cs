using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using static Questionning;

public class Questionning2 : MonoBehaviour
{

    public List<Image> imagesblack;
    public Button buttons;
    public Button nextbutton;
    public Button finishbutton;
    public List<string> questions = new();
    //public List<Answer> answer = new();
    public AnswersRandomizer randomizer;
    List<string> chosenTags;
    public TextMeshProUGUI questiontext;
    public TextMeshProUGUI amountofquestions;
    int currentQuestion;
    int amountofqustion;
    string taggss;
    public Button Backbutton;

    List<string> previousanswers = new();   
    Dictionary<string, int> tags = new Dictionary<string, int>()
    {
      { "Programming", 0 },
      { "Art", 0 },
      { "Social", 0 },
    };

 

    // Start is called before the first frame update
    void Start()
    {
        questiontext.text = questions[0];
        amountofqustion = 1;
        currentQuestion = 1;
    }

    // Update is called once per frame
    void Update()
    {
      
        if(amountofqustion == 1) 
        {
            Backbutton.gameObject.SetActive(false);           
        
        
        }

        else
        {

            Backbutton.gameObject.SetActive(true);

        }


        //print(currentQuestion);
        //print(randomizer.buttons.Count(x => x.transform.GetChild(1).gameObject.activeInHierarchy));

    }

    //void Check()
    //{
    //    foreach (var tag in chosenTags)
    //    {
    //        if (tags.ContainsKey(tag))
    //            tags[tag]++;

    //    }

    //    // Order from largest to smallest
    //    // which studies
    //}


    public void ButtonPressed(Button button)
    {

        buttons = button;
        imagesblack.ForEach(imagesblack =>  imagesblack.transform.GetChild(1).gameObject.SetActive(false));
        buttons.transform.GetChild(1).gameObject.SetActive(true);
        

    }


    public void ButtonNext()
    {
       
       
        if(randomizer.buttons.Count(x=> x.transform.GetChild(1).gameObject.activeInHierarchy) > 0)

        {
                ++tags[buttons.transform.GetChild(2).tag];
                taggss = buttons.transform.GetChild(2).tag;
                previousanswers.Add(taggss);
                amountofqustion++;
                randomizer.Randoming();
                NextQuestion();
                buttons = null;
          
        }





        foreach (var tag in tags)
        {

            //print(tag.Key + tag.Value);


        }


    }


    void NextQuestion()
    {
        
        questiontext.text = questions[currentQuestion];
        amountofquestions.text = amountofqustion.ToString() + "/5";
        buttons.transform.GetChild(1).gameObject.SetActive(false);
        currentQuestion++;
        if (questions.Count == currentQuestion ) // last question
        {
            nextbutton.gameObject.SetActive(false);
            finishbutton.gameObject.SetActive(true);
            currentQuestion = 5;
            
        }

        //print(currentQuestion);


    }


    public void Back() 
    {
        if ( amountofqustion != 1 && taggss != "") 
        
        {
            randomizer.buttons.ForEach(x => x.transform.GetChild(1).gameObject.SetActive(false));
            nextbutton.gameObject.SetActive(true);
            --tags[previousanswers[previousanswers.Count - 1]];
            previousanswers.RemoveAt(previousanswers.Count - 1);
            amountofqustion--;


            
            --currentQuestion;
            questiontext.text = questions[amountofqustion-1];
            amountofquestions.text = amountofqustion.ToString() + "/5";
            finishbutton.gameObject.SetActive(false);

            //print("adada");
        }

      


    }

    public void FinishQuestenning()
    {

        if (randomizer.buttons.Count(x => x.transform.GetChild(1).gameObject.activeInHierarchy) > 0)
        {
            tags[buttons.transform.GetChild(2).tag]++;

            tags.TryGetValue("Programming", out int Programming);

            tags.TryGetValue("Art", out int Art);

            tags.TryGetValue("Social", out int Social);


            if (Programming > Art && Programming > Social)
            {

                SceneManager.LoadScene("StoryPopUp");

            }

            if (Art > Programming && Art > Social)
            {

                SceneManager.LoadScene("StoryPopUp");

            }


            if (Social > Programming && Social > Art)
            {

                SceneManager.LoadScene("StoryPopUp 1");

            }


        }


       
    }

 
}
