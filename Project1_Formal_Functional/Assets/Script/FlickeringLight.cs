using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{

    private Light _light;

    public bool IsFlickeringLight;

    private bool isFlickering;

    public float OnDuration = 0;
    // Start is called before the first frame update
    void Start()
    {
        _light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsFlickeringLight)return;
        if(!isFlickering)StartCoroutine(FlickerLight());
    }

    IEnumerator FlickerLight(){
        isFlickering = true;
        _light.enabled = false;
        yield return new WaitForSeconds(Random.Range(0.01f, 0.2f));
        _light.enabled = true;
        yield return new WaitForSeconds(Random.Range(0.01f, 0.2f));
        _light.enabled = false;
        do{
            yield return new WaitForSeconds(Random.Range(0.01f, 0.5f));
            _light.enabled = true;
            yield return new WaitForSeconds(Random.Range(0.01f, 0.1f));
            _light.enabled = true;
        }while(Random.value<.5);
        yield return new WaitForSeconds(OnDuration);
        isFlickering = false;
    }
}
