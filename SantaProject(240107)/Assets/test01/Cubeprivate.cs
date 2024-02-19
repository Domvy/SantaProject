using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubeprivate : MonoBehaviour
{
    private int index;
    // Start is called before the first frame update
   public void setint(int i)
    {
        index = i;
    }

    public int getint()
    {
        return index;
    }
}
