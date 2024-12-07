using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiInventoryManager : MonoBehaviour
{

    public List<Image> listofslots;
    public Sprite weapon;
    public Sprite Bullets;
    public Sprite Medic;
    public Image hpindecator;
    private int index = 1;
    public GameObject inventory;
    public Sprite defaultsprite;
    public int slotsfreecount;
    public MovementStateMachine moving;
    public RotationStateMachine rotation;
    public ShootingStateMachine shooting;
    public GameObject GameOverPanel;
    public GameObject GameWonPanel;
    // Start is called before the first frame update
    void Start()
    {
        hpindecator.color = new Color(47f / 255f, 133f / 255f, 0f / 255f, 178f / 255f);
    }

    // Update is called once per frame
    void Update()
    {
        OpenInvent();
        slotsfreecount = 0;
        for (int i = 1; i < listofslots.Count; i++)
        {
            if (listofslots[i].transform.GetChild(0).GetComponent<Image>().sprite.name == "сcrosshair-removebg-preview")
            {
                
                slotsfreecount++;
                
            }
        }


        


    }

    public void SetSprite(Sprite sprite)
    {
        for(int i = 1; i < listofslots.Count; i++)
        {
            if (listofslots[i].transform.GetChild(0).GetComponent<Image>().sprite.name == "сcrosshair-removebg-preview")
            {
                index = i;
                
                break;
            }
        }
        listofslots[index].transform.GetChild(0).GetComponent<Image>().sprite = sprite;
       // index++;
    }
     
    public void OpenInvent()
    {
        if(Input.GetKeyDown(KeyCode.Tab)) 
        {
            inventory.SetActive(!inventory.activeInHierarchy);

            
            Cursor.visible = inventory.activeInHierarchy;
         if(inventory.activeInHierarchy == false)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }

            if (inventory.activeInHierarchy == true)
            {
                Cursor.lockState = CursorLockMode.None;
            }

            moving.enabled = !moving.enabled;
            shooting.enabled = !shooting.enabled;
            rotation.enabled = !rotation.enabled;
           
        }
        

    }
    

    public void UseButton(Image im)
    {
        if (im.transform.GetChild(0).GetComponent<Image>().sprite == Medic )
        {

            im.transform.GetChild(1).gameObject.SetActive(true);
        

        }


        if (im.transform.GetChild(0).GetComponent<Image>().sprite == Bullets)
        {

            im.transform.GetChild(1).gameObject.SetActive(true);
          
        }
        
    }
    public void UseMedics(Image im)
    {
        if (im.transform.GetChild(0).GetComponent<Image>().sprite == Medic)
        {
            if (hpindecator.color.r == 117f / 255f && hpindecator.color.g == 24f / 255f && hpindecator.color.b == 24f / 255f)
            {
                hpindecator.color = new Color(236f / 255f, 171f / 255f, 14f / 255f);

            }


            else if (hpindecator.color.r == 236f / 255f && hpindecator.color.g == 171f / 255f && hpindecator.color.b == 14f / 255f)
            {
                hpindecator.color = new Color(47f / 255f, 133f / 255f, 0f / 255f);

            }

            im.transform.GetChild(0).GetComponent<Image>().sprite = defaultsprite;

        }


  

      
    }


    public void DiedTryAgainButton()
    {
        SceneManager.LoadScene("NewOne");


    }

    public void UseBullets(Image im)
    {

        if(im.transform.GetChild(0).GetComponent<Image>().sprite == Bullets)
        {
            this.shooting.totalammo += 5;
            im.transform.GetChild(0).GetComponent<Image>().sprite = defaultsprite;

        }
     

    }




    public void Buttoninactive(Button im)
    {

        im.gameObject.SetActive(false);


    }
   
}
