using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageOut : MonoBehaviour
{
    [SerializeField] StagerData stagdata;
    private float destroyweight = 2.0f;
    

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < stagdata.LimitMin.y - destroyweight ||
           transform.position.y > stagdata.LimitMax.y + destroyweight ||
           transform.position.x < stagdata.LimitMin.x - destroyweight ||
           transform.position.x > stagdata.LimitMax.x + destroyweight )
        {
            Destroy(gameObject);
        }
    }
}
