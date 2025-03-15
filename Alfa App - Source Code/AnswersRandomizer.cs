using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswersRandomizer : MonoBehaviour
{

    public List<TextMeshProUGUI> answers = new List<TextMeshProUGUI>();
    public List<Button> buttons = new List<Button>();
    public List<int> indexes = new List<int>();
    // Start is called before the first frame update

    void Start()
    {
        //answers[0].transform.parent = buttons[0].transform;
        //answers[0].transform.localPosition = new Vector2(400,0);
   

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Randoming()
    {

        while (indexes.Count != 3)
        {
            int randomindex = Random.Range(0, 3);
            if (!indexes.Contains(randomindex))
            {
                indexes.Add(randomindex);
            }

        }
        for (int i = 0; i < answers.Count; i++)
        {
            answers[indexes[i]].transform.parent = buttons[i].transform;
            answers[indexes[i]].transform.localPosition = new Vector2(600, 0);


        }
       
        indexes.Clear();
    }



}
