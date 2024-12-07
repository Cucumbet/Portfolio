using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class InventoryManager : MonoBehaviour
{

    private List<GameObject> listofitems = new List<GameObject>();
    private GameObject ActiveItem;
    public GameObject ItemBullets;
    public GameObject ItemMedic;
    //public Bullets bullets;
    public GameObject itemtopick;

  
   
    public GameObject activeItem => ActiveItem;
    public List<GameObject> list => listofitems;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetItem(GameObject item)
    {
        itemtopick = item;
        if(item.transform.tag == "Itemgun")
        {

            ActiveItem = item;
        }

        if (item.transform.tag == "Bullets")
        {

            ItemBullets = item;
            
        }


        if (item.transform.tag == "Medic")
        {

            ItemMedic = item;

        }

    }
    public void SetPistol(GameObject item)
    {
        
            ActiveItem.SetActive(true);
            ActiveItem.transform.localPosition = ActiveItem.GetComponent<Item>().Position;
            ActiveItem.transform.localEulerAngles= ActiveItem.GetComponent<Item>().Rotation;
            ActiveItem.GetComponent<Rigidbody>().isKinematic = true;
            ActiveItem.GetComponent<Item>().Weaponimage.gameObject.SetActive(true);


    }
    // Update is called once per frame
   
    void Update()
    {
     
       
      
    }
}
