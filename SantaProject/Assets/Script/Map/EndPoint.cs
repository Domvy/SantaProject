using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Transform gamePad;
    [SerializeField]
    private GameObject playerObj;
    GameObject jumpBtn;
    GameObject endBtn;

    public EndSent endSent;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        gamePad = GameObject.FindWithTag("GamePad").transform;
        jumpBtn = gamePad.Find("JumpButton").gameObject;
        endBtn = gamePad.Find("EndButton").gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            jumpBtn.SetActive(false);
            endBtn.SetActive(true);
            playerObj = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            jumpBtn.SetActive(true);
            endBtn.SetActive(false);
            playerObj = null;
        }
    }

    public void EndStage()
    {
        if (playerObj != null) {
            //playerObj.SetActive(false);
            playerObj.transform.GetChild(0).gameObject.SetActive(false);
            animator.SetTrigger("End"); 
        }
        gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine(endSent.Endpoint());
    }
    
}
