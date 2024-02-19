using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocksMgr : MonoBehaviour
{
   public static int add=0;
    private void Start()
    {
        add = 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Present"))
        {
            add++;
            print("P"+add);
        }
    }
}

