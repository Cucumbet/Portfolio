using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Demons : MonoBehaviour
{
    public List<GameObject> demonslist = new List<GameObject>();
    public List<ParticleSystem> fakeonslist = new List<ParticleSystem>();
    public List<ParticleSystem> realonslist = new List<ParticleSystem>();
    int index = 0;
    int indexreal = 0;
    public GameObject demon;
    float time;
    int count;
    float X, Z = 0;
    float angle = 30;
    public GameObject player;
    float seconds = 0;
    int deathcount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        seconds += Time.deltaTime;
        Spawnning();
        


    }
    List<int> Nums = new List<int>();

    public void SpawnParticle()
    {
        foreach(var i in demonslist)
        {
            if (index < fakeonslist.Count)
            {
                int RandIndex = Nums[Random.Range(0, Nums.Count)];
                ParticleSystem particleSystem = Instantiate(fakeonslist[0]);
                particleSystem.transform.SetParent(demonslist[RandIndex].transform);
                particleSystem.transform.localPosition = Vector3.zero;
                index++;

                Nums.RemoveAll(i => i == RandIndex);

            }


            else if (indexreal < realonslist.Count)
            {
                int RandIndex = Nums[Random.Range(0, Nums.Count)];
                ParticleSystem particleSystem = Instantiate(realonslist[0]);
                particleSystem.transform.SetParent(demonslist[RandIndex].transform);
                particleSystem.transform.localPosition = Vector3.zero;
                indexreal++;
                Nums.RemoveAll(i => i == RandIndex);
            }
        }
    }
   
    public void Spawnning()
    {

       
            if (time > 0.1 && count < 5 && seconds > 3)
            {

                GameObject Clone = Instantiate(demon);

                demonslist.Add(Clone);
                Clone.transform.position = new Vector3(player.transform.position.x + Mathf.Cos(angle) * 20, demon.transform.position.y + 7.5f, player.transform.position.z + Mathf.Sin(angle) * 20);
                Clone.transform.rotation = Quaternion.LookRotation(player.transform.position - Clone.transform.position);
                Clone.transform.rotation = new Quaternion(0, Clone.transform.rotation.y, 0, Clone.transform.rotation.w);
                Clone.transform.eulerAngles = new Vector3(Clone.transform.eulerAngles.x, Clone.transform.eulerAngles.y - 90, Clone.transform.eulerAngles.z);
                Nums.Add(demonslist.IndexOf(Clone));

               
            //  if(index< fakeonslist.Count)
            //  {
            //    ParticleSystem particleSystem = Instantiate(fakeonslist[0]);
            //    particleSystem.transform.SetParent(Clone.transform);
            //    particleSystem.transform.localPosition = Vector3.zero;
            //    index++;

            //  }


            //else  if(indexreal< realonslist.Count) 
            //{
            //    ParticleSystem particleSystem = Instantiate(realonslist[0]);
            //    particleSystem.transform.SetParent(Clone.transform);
            //    particleSystem.transform.localPosition = Vector3.zero;
            //    indexreal++;

            //}


            angle += 80;
                time = 0;
                count += 1;
            }
            if( count >= 5)
           {
            SpawnParticle();
            }


        if (seconds > 10)
        {
            foreach (GameObject t in demonslist)
            {
                Destroy(t);


            }
            demonslist.Clear();
            seconds = 0;
            count = 0;
            index = 0;
            indexreal = 0;
        }



    }

  

}
