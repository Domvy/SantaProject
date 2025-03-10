using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UserDatabase;

public class Pipe : MonoBehaviour
{
    private Collider2D collider;
    private GameObject smokeObject;

    private void Awake()
    {
        collider = this.GetComponent<Collider2D>();
        smokeObject = this.transform.GetChild(0).gameObject;
    }
    private void OnEnable()
    {
        StartCoroutine(Smoke());
    }
    IEnumerator Smoke()
    {
        while (true) 
        {            
            collider.enabled = true;
            smokeObject.SetActive(true);
            yield return new WaitForSeconds(3.0f);
            collider.enabled = false;
            yield return new WaitForSeconds(3.0f);
        }        
    }
}
