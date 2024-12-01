using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLight : MonoBehaviour
{

    private Light _light;

    public float timeBetweenBlinks;

    private bool isBlinking = false;
    // Start is called before the first frame update
    void Start()
    {
        _light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isBlinking) StartCoroutine(BlinkLight());
    }

    IEnumerator BlinkLight(){
        isBlinking = true;
        _light.enabled = true;
        yield return new WaitForSeconds(timeBetweenBlinks);
        _light.enabled = false;
        yield return new WaitForSeconds(timeBetweenBlinks);
        isBlinking = false;
    }
}
