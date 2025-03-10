using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerImage : MonoBehaviour
{
    private PlayerCtrl playerCtrl;
    private SpriteRenderer playerRenderer;
    public Animator moveAnimator;
    private bool isMove;
    private bool isJump;
    private bool isHanging;
    private void Awake()
    {
        playerRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        moveAnimator = gameObject.GetComponent<Animator>();
        playerCtrl = gameObject.GetComponent<PlayerCtrl>();
    }
    private void FixedUpdate()
    {
        isMove = playerCtrl.isMove;
        isJump = playerCtrl.isJump;
        isHanging = playerCtrl.isHanging;

        if (isHanging)
        {
            moveAnimator.SetBool("Move", false);
            moveAnimator.SetBool("Jump", false);
            moveAnimator.SetBool("Hanging", true);
        }
        else if (isJump)
        {
            moveAnimator.SetBool("Move", false);
            moveAnimator.SetBool("Jump", true);
            moveAnimator.SetBool("Hanging", false);
        }
        else if (isMove)
        {
            moveAnimator.SetBool("Move", true);
            moveAnimator.SetBool("Jump", false);
            moveAnimator.SetBool("Hanging", false);
        }
        else
        {
            moveAnimator.SetBool("Move", false);
            moveAnimator.SetBool("Jump", false);
            moveAnimator.SetBool("Hanging", false);
        }
    }
    public void FlipImage(float direction)
    {
        if (direction > 0) { playerRenderer.flipX = true; }
        else if (0 > direction) { playerRenderer.flipX = false; }
    }
    public void DamagedImageCo(int maxtime)
    {
        StartCoroutine(DamagedImage(maxtime));
    }
    public IEnumerator DamagedImage(float maxtime)
    {
        int time = 0;
        while (time < maxtime * 2)
        {
            if (time % 2 == 0) { playerRenderer.color = new Color32(255, 255, 255, 90); }
            else { playerRenderer.color = new Color32(255, 255, 255, 180); }
            time++;
            yield return new WaitForSeconds(0.5f);
        }
        playerRenderer.color = new Color32(255, 255, 255, 255);
        StopCoroutine(DamagedImage(0));
        yield return null;
    }
}
