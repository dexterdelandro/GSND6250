using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;



public class PostProcessControl : MonoBehaviour
{
    public Volume postProcessingVolume;
    public Vignette vignette;

   // public float intensityV;

   // public float freezeDuration = 3f;

    public float changePerSecond = 0.1f;
    public bool inFire = false;
    // Start is called before the first frame update
    void Start()
    {
        postProcessingVolume.profile.TryGet(out vignette);
        vignette.intensity.value = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(vignette ==null)return;

        if(!inFire && vignette.intensity.value<1){
            vignette.intensity.value += changePerSecond * Time.deltaTime;
            if(vignette.intensity.value==1){
                Debug.Log("DIE");
            }
        } else if (inFire && vignette.intensity.value>0){
            vignette.intensity.value -= changePerSecond * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Fire")){
            inFire = true;
        }
        
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("Fire")) inFire = false;
    }
}
