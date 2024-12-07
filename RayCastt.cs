using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RayCastt : MonoBehaviour
{
   
    TextMeshPro txt;
    public InventoryManager inventoryManager;
    //public GameObject head;
    //public GameObject camerapoint;
    //public LayerMask obstacle;

    string[] tags = new string[]
    {
      "Itemgun",  "Bullets", "Medic"
    };
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

        showEmassage();

        //Debug.DrawRay(this.transform.position, ( camerapoint.transform.position - this.transform.position) * ( camerapoint.transform.position - this.transform.position).magnitude);


        //float diLenght = ( head.transform.position - this.transform.position ).magnitude;
        //Vector3 dir = (head.transform.position - this.transform.position);
        //if (Physics.Raycast(this.transform.position, dir,out RaycastHit hit,diLenght))
        //{
        //    this.transform.position = hit.point;
        //}
        //else
        //{

        //    this.transform.position = head.transform.position - this.transform.forward * 2;
        //}

        //this.transform.position = head.transform.position - this.transform.forward * 2;

        //var distance = Vector3.Distance(this.transform.position, head.transform.position);
        //if (Physics.Raycast(head.transform.position, this.transform.position - head.transform.position, out RaycastHit hit, 1,obstacle))
        //{
        //    this.transform.position = hit.point;
        //}
        //  else if (distance < 2 && !Physics.Raycast(this.transform.position, - transform.forward, 0.1f,obstacle))
        //    {

        //    this.transform.position -= transform.forward * .05f;
        //}

        
      
    }

    private void LateUpdate()
    {
     
    }
    public bool showEmassage()
    {

        if (txt != null)
        {
            txt.enabled = false;
           
        }

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, 3) && tags.Contains(hitInfo.transform.tag))
        {
            txt = hitInfo.collider.transform.GetComponentInChildren<TextMeshPro>();
            txt.enabled = true;
            if (!inventoryManager.list.Contains(hitInfo.collider.transform.gameObject))
            {
                inventoryManager.SetItem(hitInfo.collider.transform.gameObject);
                

            }
           
            return true;
        }
     


        return false;
    }


}
