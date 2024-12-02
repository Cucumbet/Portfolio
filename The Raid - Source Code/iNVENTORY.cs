using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class iNVENTORY : MonoBehaviour
{
    private UI_Inventory UI_inventory;
    public List<GameObject> Items = new List<GameObject>();
    public GameObject Active_item;
    public rAY camerrra;
    int Index = 0;
    public Main textt;
    // Start is called before the first frame update
    void Start()
    {
        
        UI_inventory = FindObjectOfType<UI_Inventory>();
        for(int i = 0; i < Items.Count; i++)
        {
            Items[i].SetActive(false);

        }
        //Active_item.SetActive(true);

    }
    bool CannotActivate = false;    // Update is called once per frame
    void Update()
    {

        if (Active_item != null && Active_item.layer == 3 && CannotActivate == false && camerrra.Hover == false)
        {
           camerrra.Rhints.enabled = true;
            
            
        }
        if(Active_item != null && Active_item.layer == 3 && CannotActivate == false && camerrra.Hover == true)
        {
            camerrra.Rhints.enabled = false;        
        
        
        }
        if (Active_item != null && Active_item.layer == 0)
        {
            
            camerrra.Rhints.enabled = false;

        }
       
        Takeup();
        
            if (Input.GetKeyDown(KeyCode.G))
            {
                Drop();

            }
        Switcher();
    }


    private void Drop()
    {
        if (Items.Count > 0)
        {
            Rigidbody droop = Active_item.GetComponent<Rigidbody>();
            droop.isKinematic = false;
            Active_item.transform.SetParent(null);
            
           
            if (Items.Count != 0)
            {
                
                // Active_item = Items[Items.Count - 1];
                //if (Active_item.layer == 3)
                //{
                //    CannotActivate = true;
                //    camerrra.Rhints.enabled = false;
                //}
                UI_inventory.disactive_slot(Items.IndexOf(Active_item));
                Items.Remove(Active_item);
                Activates_next_item(Active_item);
               
            }
                   
        }
       

       //if(Items.Count == 0)
       // {
       //     Active_item = null;
       //     UI_inventory.disactive_slot("");

       // }
    }
    private void Takeup()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && Items.Count < 4)
        {
            
            Ray rayy = new Ray();
            rayy.direction = Camera.main.transform.forward;
            rayy.origin = Camera.main.transform.position;
            RaycastHit hitItem;
           
            if (Physics.Raycast(rayy.origin, rayy.direction, out hitItem, 5))
            {
                if (hitItem.transform.tag == "note")
                {
                   
                    if(hitItem.transform.gameObject.layer == 3)
                    {
                        CannotActivate = false;
                        
                    }
                  
                    Items.Add(hitItem.transform.gameObject);
                    Active_item = Items[Items.Count -1 ];
                    Active_item.GetComponent<Rigidbody>().isKinematic = true;
                    Active_item.transform.SetParent(Camera.main.transform);
                    Active_item.transform.localPosition = Active_item.GetComponent<ITEM>().Position;
                    Active_item.transform.localRotation = Active_item.GetComponent <ITEM>().Rotation;
                  
                    if (Active_item.GetComponent<MeshRenderer>())
                    {
                        UI_inventory.active_slot(Active_item.GetComponent<MeshRenderer>().material.mainTexture);
                       
                    }
                                       
                    for(int i = 0; i < Items.Count; i++)
                    {
                        Items[i].SetActive(false);
                    }

                    Active_item.SetActive(true);
                    UI_inventory.TagItem = Active_item.layer;
                    UI_inventory.currentdiscript = Active_item.GetComponent<ITEM>().Description; //new
                    //print(UI_inventory.currentdiscript);
                }
            }
        }
    }


    private void Activates_next_item(GameObject Next_item)
    {

        Next_item.SetActive(true);
       
    }
    private void disactive(GameObject Ittem)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            Items[i].SetActive(false);
        }
        Active_item = Ittem;
        Ittem.SetActive(true);
    }
    private void Switcher()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            
            disactive(Items[0]);

            int Index = 0;
            for (int i = 0; i < UI_inventory.sprites.Count; i++)
            {
                Sprite sprite = null;

                sprite = Sprite.Create((Texture2D)Active_item.GetComponent<Renderer>().material.mainTexture, new Rect(0, 0, Active_item.GetComponent<Renderer>().material.mainTexture.width, Active_item.GetComponent<Renderer>().material.mainTexture.height), Vector2.zero);
                //print(UI_inventory.sprites[i].texture);
                //print(sprite.texture);
                if (UI_inventory.sprites[i].texture == sprite.texture)
                {
                    Index = i;
                    
                    break;

                }
            }

            UI_inventory.current_sprite = UI_inventory.sprites[Index];
            UI_inventory.Clicks = 0;
            UI_inventory.FreeIndexSlot = Index;
            UI_inventory.TagItem = Active_item.layer;
            UI_inventory.currentdiscript = Active_item.GetComponent<ITEM>().Description;//NEW
            if (Active_item.layer == 3 && camerrra.Hover == false)
            {

               camerrra.Rhints.enabled = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
          
            disactive(Items[1]);

            int Index = 0;
            for (int i = 0; i < UI_inventory.sprites.Count; i++)
            {
                Sprite sprite = null;

                sprite = Sprite.Create((Texture2D)Active_item.GetComponent<Renderer>().material.mainTexture, new Rect(0, 0, Active_item.GetComponent<Renderer>().material.mainTexture.width, Active_item.GetComponent<Renderer>().material.mainTexture.height), Vector2.zero);
                //print(UI_inventory.sprites[i].texture);
                //print(sprite.texture);
                if (UI_inventory.sprites[i].texture == sprite.texture)
                {
                    Index = i;
                   
                    break;

                }
            }

            UI_inventory.current_sprite = UI_inventory.sprites[Index];
            UI_inventory.Clicks = 0;
            UI_inventory.FreeIndexSlot = Index;
            UI_inventory.TagItem = Active_item.layer;
            UI_inventory.currentdiscript = Active_item.GetComponent<ITEM>().Description;//NEW
            if (Active_item.layer == 3 && camerrra.Hover == false)
            {

               camerrra.Rhints.enabled = true;
            }
        }


        if (Input.GetKeyDown(KeyCode.Alpha3))
        {

            disactive(Items[2]);

            int Index = 0;
            for (int i = 0; i < UI_inventory.sprites.Count; i++)
            {
                Sprite sprite = null;

                sprite = Sprite.Create((Texture2D)Active_item.GetComponent<Renderer>().material.mainTexture, new Rect(0, 0, Active_item.GetComponent<Renderer>().material.mainTexture.width, Active_item.GetComponent<Renderer>().material.mainTexture.height), Vector2.zero);
                //print(UI_inventory.sprites[i].texture);
                //print(sprite.texture);
                if (UI_inventory.sprites[i].texture == sprite.texture)
                {
                    Index = i;

                    break;

                }
            }

            UI_inventory.current_sprite = UI_inventory.sprites[Index];
            UI_inventory.Clicks = 0;
            UI_inventory.FreeIndexSlot = Index;
            UI_inventory.TagItem = Active_item.layer;
            UI_inventory.currentdiscript = Active_item.GetComponent<ITEM>().Description;//NEW
            if (Active_item.layer == 3 && camerrra.Hover == false)
            {

                camerrra.Rhints.enabled = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
           

            disactive(Items[3]);

            int Index = 0;
            for (int i = 0; i < UI_inventory.sprites.Count; i++)
            {
                Sprite sprite = null;

                sprite = Sprite.Create((Texture2D)Active_item.GetComponent<Renderer>().material.mainTexture, new Rect(0, 0, Active_item.GetComponent<Renderer>().material.mainTexture.width, Active_item.GetComponent<Renderer>().material.mainTexture.height), Vector2.zero);
                //print(UI_inventory.sprites[i].texture);
                //print(sprite.texture);
                if (UI_inventory.sprites[i].texture == sprite.texture)
                {
                    Index = i;
                    
                    break;

                }
            }

            UI_inventory.current_sprite = UI_inventory.sprites[Index];
            UI_inventory.Clicks = 0;
            UI_inventory.FreeIndexSlot = Index;
            UI_inventory.TagItem = Active_item.layer;
            UI_inventory.currentdiscript = Active_item.GetComponent<ITEM>().Description;//NEW
            if (Active_item.layer == 3 && camerrra.Hover == false)
            {

                camerrra.Rhints.enabled = true;
            }
        }
    }
    }
    

    
    





