using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBtn : MonoBehaviour
{
    public GameObject offOBJ;
    public GameObject onOBJ;

    public void OnBtn()
    {
        if (offOBJ != null) { offOBJ.SetActive(false); }
        
        onOBJ.SetActive(true);
    }
}
