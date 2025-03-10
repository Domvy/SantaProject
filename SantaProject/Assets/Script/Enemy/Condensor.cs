using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condensor : MonoBehaviour
{
    float destroyTime = 3f;
    public void DropThis()
    {
        this.gameObject.GetComponent<Animator>().SetTrigger("Drop");
    }    
    IEnumerator Distroy()
    {
        float time = 0;
        while (time <= destroyTime) 
        {
            time += 1f;
            yield return new WaitForSeconds(1f);
        }
        Destroy(gameObject);
    }
}

