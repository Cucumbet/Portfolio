using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZombiASpawner : Factory
{
    [SerializeField] private ZombieA SavePrefab;

    public ZombiASpawner(ZombieA Prefab)
    {
      SavePrefab = Prefab;  
    }
    public override IZombie Spawn(Vector3 position)
    {
        
        // create a Prefab instance and get the product component
        GameObject instance = Instantiate(SavePrefab.gameObject,
       position, Quaternion.identity);
        ZombieA newProduct = instance.GetComponent<ZombieA>();
        // each product contains its own logic
        return newProduct;
    }

    public void Start()
    {
           
    }
}
