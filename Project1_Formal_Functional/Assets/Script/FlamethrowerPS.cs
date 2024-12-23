using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerPS : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem particleSystem;
    private bool isOn = true;
    void Start()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();
        GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        particleSystem.Stop();
        isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isOn) StartCoroutine(EmmitFlame());

    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Enemy"){
            Destroy(other.gameObject);
            //take damage
        }
    }

    IEnumerator EmmitFlame(){
        isOn = true;
        particleSystem.Play();
      //  Debug.Log("fire");
        yield return new WaitForSeconds(Random.Range(1,6)); //random emmit duration time
        particleSystem.Stop();
     //   Debug.Log("wait");
        yield return new WaitForSeconds(Random.Range(3,10)); //random wait time
        isOn = false;

    }
}
