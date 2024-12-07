using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{

    [SerializeField] Vector3 position;
    [SerializeField] Vector3 rotation;
    
    public Vector3 Position => position;
    public Vector3 Rotation => rotation;
    [SerializeField] Image weaponimage;

    public Image Weaponimage => weaponimage;

   

    public virtual void AddingSprite()
    {

    }

    public virtual void DeletingSprite()
    {


    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
