using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Sense : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool click;
    public Text Percentages;

    // Start is called before the first frame update
    void Start()
    {
        Percentages.text = ((int)(PlayerPrefs.GetFloat("Sensa") * 100)).ToString();
        this.transform.localPosition = new Vector3(((330 * (int)(PlayerPrefs.GetFloat("Sensa") * 100)) / 100) - 165, 0);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        click = false;

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        click = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (click == true)
        {
            Percentages.text = ((int)(((this.transform.localPosition.x + 165) / 330) * 100)).ToString() + "%";
            PlayerPrefs.SetFloat("Sensa", ((this.transform.localPosition.x + 165) / 330) );
            Vector2 vector2 = Input.mousePosition;
            vector2.x -= Screen.width / 2;
            vector2.x = Mathf.Clamp(vector2.x, -165, 165);
            vector2.y = 0;
            this.transform.localPosition = vector2;

        }

    }
}