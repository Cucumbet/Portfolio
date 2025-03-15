using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookScript : MonoBehaviour
{

    public GameObject fish;
    public FishScript fishescript;
    //public Animator animatorfish;
    public bool hokey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(fish.transform.position, this.transform.position) < 1)
        {
            hokey = true;
            fishescript.fishk = false;
            //animatorfish.enabled = false;
            fish.transform.localPosition = new Vector3(0, 0, 0);
            fish.transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        if(hokey == true)
        {
            fish.transform.position = Vector3.Lerp(fish.transform.position, this.transform.position, 1);
        }
    }

    
}
