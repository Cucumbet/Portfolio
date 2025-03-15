using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject wOLFs;
    public List <GameObject> Spawnpoint;
    public List <GameObject> Wolfs = new List<GameObject>();
    public GameObject fish;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn()); 
    }
    private IEnumerator spawn()
    {






        while (true)
            {
            if(!fish.activeInHierarchy) 
            {
                yield return new WaitForSeconds(15);
                GameObject clone = Instantiate(wOLFs);
                clone.transform.position = Spawnpoint[Random.Range(0, 3)].transform.position;
                clone.SetActive(true);
                Wolfs.Add(clone);

            }
            yield return new WaitForSeconds(1);
        }
        

        
     
       
    }


    public void RemoveWolf(GameObject wolf)
    {
        Wolfs.Remove(wolf);
    }

    // Update isalled once per frame
    void Update()
    {
        
    }
}
