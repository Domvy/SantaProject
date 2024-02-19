using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTarget : MonoBehaviour
{
    private Transform parentObj;
    public string name;

    private void Start()
    {
        parentObj = gameObject.transform.parent;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (name)
            {
                case "Bird":
                    parentObj.GetComponent<Birds>().FindTarget(collision.transform);
                    break;
                case "Condensor":
                    parentObj.GetComponent<Condensor>().DropThis();
                    break;
            }
        }                    
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (name)
        {            
            case "Dog":
                parentObj.GetComponent<Dogs>().FindTarget(collision.transform);
                break;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (name)
        {
            case "Dog":
                parentObj.GetComponent<Dogs>().MissTarget();
                break;
        }
    }
}
