using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoots : MonoBehaviour
{
    private GameObject Body;
    private Rigidbody2D playerRigid;

    private void Start()
    {
        Body = gameObject.transform.parent.gameObject;
        playerRigid = Body.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)// �ٴ� �浹 �� ���� �ʱ�ȭ
    {
        if (playerRigid.velocity.y <= 0 && collision.gameObject.tag == "Ground") { Body.GetComponent<PlayerCtrl>().JumpOver(); }
    }
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Ground") { Body.GetComponent<PlayerCtrl>().Jumpping(); }
    //}
}
