using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentCtl : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    Vector2 startpos, endpos, direction;
    float touchTimeStart, touchTimefinish, timeInterval;

    [SerializeField]
    [Range(0.05f, 1f)] float throwForce = 0.3f;

    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        audio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount>0 && Input.GetTouch(0).phase==TouchPhase.Began)//손가락 하나,터치했을때
        {
            touchTimeStart = Time.time;
            startpos = Input.GetTouch(0).position;
        }
        if(Input.touchCount>0&&Input.GetTouch(0).phase==TouchPhase.Ended)//손가락 하나,터치뗐을때
        {
            touchTimefinish = Time.time;
            timeInterval = touchTimefinish - touchTimeStart;
            endpos = Input.GetTouch(0).position;
            direction = startpos - endpos;
            if (SocksMgr.add == 0)
            { rigidbody2D.AddForce(-direction / timeInterval * throwForce); }//선물이 움직이는 정도 힘+방향+속도
            Sound();
        }
    }
    void Sound()
    {
        audio.Play();
    }
}
