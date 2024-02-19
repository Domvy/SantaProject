using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRE : MonoBehaviour
{

    public int newRE;
    REclass reclass = new REclass();

    // Start is called before the first frame update
    void Start()
    {
        reclass.reM = newRE;
    }

  
}
