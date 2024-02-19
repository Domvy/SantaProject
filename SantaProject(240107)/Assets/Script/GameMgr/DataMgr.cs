using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UserDatabase;

public class DataMgr : MonoBehaviour
{    
    public Data data;    

    private void Awake()
    {
        data = Resources.Load<Data>("Data/Data");
    }
}
