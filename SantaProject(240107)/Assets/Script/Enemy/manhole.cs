using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UserDatabase;

public class manhole : MonoBehaviour
{
    //private Data gameCtrlData;
    public void Start()
    {
        //gameCtrlData = GameObject.FindWithTag("GameController").GetComponent<DataMgr>().data;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //gameCtrlData.maxHP = 0;
            collision.GetComponent<PlayerCtrl>().Damaged(collision.transform);
        }
    }
}
