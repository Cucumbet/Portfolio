using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class UI_Inventory : MonoBehaviour
{
    public List<Image> images = new List<Image>();
    public List<Sprite> sprites = new List<Sprite>();
    public int FreeIndexSlot;
    public Sprite current_sprite;
    public Text descript; //new
    public Image inventscreen; //new
    public string currentdiscript; //new
    public GameObject slots;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void active_slot(Texture texture)
    {
        //int Index = 0;
        //for (int i = 0; i < sprites.Count; i++)
        //{
        //    if (sprites[i].name == spritename)
        //    {
        //        Index = i;
        //        break;

        //    }
        //}
        //    images[FreeIndexSlot].transform.GetChild(0).GetComponent<Image>().sprite = sprites[Index];
        //    if(FreeIndexSlot == 0)
        //   {
        //    disRead();

        //   }
        //    current_sprite = sprites[Index];
        //    panel.sprite = current_sprite;
        //    FreeIndexSlot++;
        Sprite sprite = null;
        if (texture != null && texture is Texture2D)
        {
            sprite = Sprite.Create((Texture2D)texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
        int index = sprites.Count;
        sprites.Add(sprite);
        images[index].transform.GetChild(0).GetComponent<Image>().sprite = sprite;
        current_sprite = sprite;
    }

    public void disactive_slot(int Index)
    {
        
       
        sprites.RemoveAt(Index);
        for(int i = 0; i < images.Count; i++)
        {
            images[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
        }
        for (int i = 0; i < sprites.Count; i++) 
        {
            images[i].transform.GetChild(0).GetComponent<Image>().sprite = sprites[i];
        }
       
    }

    public Image panel;
    bool iscalSwitch;
    public Sprite sprr;
    public void Note_Read()
    {


            inventscreen.enabled = true; //new
            panel.sprite = current_sprite;
            panel.gameObject.SetActive(true);
            descript.text = currentdiscript; //new
            slots.gameObject.SetActive(false);//new
            //new


    }

    public int Clicks;
    
    public void disRead() 
    {
        
        panel.sprite = null;
        panel.gameObject.SetActive(false);
        descript.text = ""; //new
        inventscreen.enabled = false; //new
        slots.gameObject.SetActive(true);//new
        //new
    }
    public LayerMask TagItem;
    void Update()
    {
        if (TagItem == 3)
        {


            if (Input.GetKeyUp(KeyCode.R))
            {
                Clicks++;
                iscalSwitch = false;
                

            }


            if (Clicks % 2 != 0 && current_sprite != null)
            {
                Note_Read();
            }
            else
            {
                disRead();
            }

        }
    }
   

}
