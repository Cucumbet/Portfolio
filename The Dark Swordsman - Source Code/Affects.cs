using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class Affects : MonoBehaviour
{
    public PostProcessVolume postProcessVolume; 
    private AutoExposure autoExposure; 
    public float increaseStep = 0.1f;
    public float dicreaseStep = 0.1f;
    public float maxLimit = 2.0f;
    public float minLimit = 0.1f;
    public float interval = 1.0f;
    public float getsred;
    public float blinding;
    public float gettinghight;
    public float gettingpixeled;

    private Vignette gettingred;
    private DepthOfField blinded;
    private ChromaticAberration gethight;
    private Grain getpixels;
    float seconds = 0;

    // Start is called before the first frame update
    void Start()
    {

        if(postProcessVolume.profile.TryGetSettings(out getpixels))
        {



        }
        if (postProcessVolume.profile.TryGetSettings(out gethight))
        {



        }
        if (postProcessVolume.profile.TryGetSettings(out blinded))
        {



        }
        if (postProcessVolume.profile.TryGetSettings(out gettingred))
        {

            

        }


        if (postProcessVolume.profile.TryGetSettings(out autoExposure))
        { 

            InvokeRepeating(nameof(IncreaseMinExposure), interval * 5, interval);

        }


        if (postProcessVolume.profile.TryGetSettings(out autoExposure))
        {

            InvokeRepeating(nameof(DireaseMinExposure), interval, interval);

        }
    }

    // Update is called once per frame
    void Update()
    {
      
        seconds += Time.deltaTime;
        gettingred.intensity.value = getsred;
        blinded.focalLength.value = blinding;
        gethight.intensity.value = gettinghight;
        getpixels.intensity.value = gettingpixeled;
        
        
    }

    private void IncreaseMinExposure() 
    
    { 

        if (autoExposure != null && seconds > 60) 

      {

            increaseStep = 1;
            autoExposure.minLuminance.value = Mathf.Min(autoExposure.minLuminance.value + increaseStep, maxLimit);

            
           
        }

        if(getsred == 0.2f) // first one
        {
            gettinghight = 1;

        }

        if(getsred == 0.6f) // third one
        {
            gettinghight = 0;
            gettingpixeled = 1;

        }


        if(getsred >= 0.8f)
        {

            gettingpixeled = 0;

      
        }
        if(getsred > 1) // last
        {

            SceneManager.LoadScene("DieLevel1");
            

        }

        if(getsred == 1) //almost last
        {

            blinding = 20;

        }
    }


    private void DireaseMinExposure()

    {
        if (autoExposure != null && autoExposure.minLuminance.value == maxLimit)

        {

            getsred += 0.2f;
            autoExposure.minLuminance.value = Mathf.Min(autoExposure.minLuminance.value - dicreaseStep, minLimit);
           
            if (autoExposure.minLuminance.value == 0.1f)
            {

                increaseStep = 0;
                seconds = 0;
                
            }
        }
    }

    
}
