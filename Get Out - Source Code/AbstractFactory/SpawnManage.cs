using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManage : MonoBehaviour
{
    [SerializeField] GameObject[] spawnpoint;

    // Start is called before the first frame update

    Factory factory;
    [SerializeField] ZombieA zombie;
    void Start()
    {

        factory = new ZombiASpawner(zombie);
        
        //factory.Spawn(Vector3.zero);
        //factory.Spawn(new Vector3(0, 1 ,1));
        //factory.Spawn(new Vector3(0, 2, 2));
        //factory.Spawn(new Vector3(0, 3, 3));
        for(int i = 0;i < 20;i++)
        {
            factory.Spawn(spawnpoint[Random.Range(0, 4)].transform.position);
        }
    }

    // Update is called once per frame

}
