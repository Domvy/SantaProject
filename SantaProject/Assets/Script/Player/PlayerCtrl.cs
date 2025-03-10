using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UserDatabase;

public class PlayerCtrl : MonoBehaviour
{
    public Data playerData; // �⺻ ������ �����̳�
    public Data damagedData;
    public GameObject death;
    private Vector2 movedirection; // �̵� ����
    private bool canCtrl; // ���� Ȱ��ȭ
    public bool isMove; // �̵�
    public bool isJump; // ����
    public bool isHanging; // �Ŵ޸���
    public bool canJump; // ���� Ȱ��ȭ
    [SerializeField]
    private bool CanHanging; // �Ŵ޸��� Ȱ��ȭ    
    public bool canDamaged; // ������ Ȱ��ȭ
    private int bonusPow; // ���� �Ŀ� ����
    private int jump; // ���� Ƚ�� ī��Ʈ
    private float timer; // �̵� �Ұ� Ÿ�̸�
    private Transform nowCollisionObj;
    private Rigidbody2D playerRigid;
    private Collider2D bootsCollider;
    AudioSource audio;
    public List<AudioClip> audioClipList;

    private void Start()
    {
        //�⺻ �÷��̾� Ŭ���� ����
        playerData = Resources.Load<Data>("Data/Data");
        damagedData = Resources.Load<Data>("Data/Data");
        playerRigid = gameObject.GetComponent<Rigidbody2D>();
        audio = gameObject.GetComponent<AudioSource>();
        canCtrl = true;
        isMove = false;
        isJump = false;
        isHanging = false;
        canJump = true;
        CanHanging = false;
        canDamaged = true;
        jump = 0;
        bonusPow = 100;
        timer = 0;
    }
    private void Update()
    {
        if (canCtrl)
        {
            // �̵� ����
            isMove = (movedirection != Vector2.zero && movedirection.y == default);
            if (isMove)
            {
                Vector2 velocity = new Vector2(movedirection.x, movedirection.y);
                if (isHanging)
                {
                    gameObject.transform.Translate(movedirection * playerData.moveSpeed * Time.deltaTime);
                }
                if (!isHanging)
                {
                    velocity.x += movedirection.x * playerData.moveSpeed;
                    playerRigid.velocity = new Vector2(velocity.x, playerRigid.velocity.y);
                }
            }
            // ���� ����
            if (playerData.jumpCount == jump) { canJump = false; }
            else { canJump = true; }
        }
        if (!canCtrl) { CanCtrl(); }
        if (!CanHanging) { if (isHanging) { HangingOver(); } }
    }
    public void OnMove(InputValue value) // Input System �̵� �Լ�
    {
        movedirection = value.Get<Vector2>();
        gameObject.GetComponent<PlayerImage>().FlipImage(movedirection.x);
    }
    void OnJump() // Input System ���� �Լ�
    {
        if (canCtrl)
        {
            if (CanHanging && !isHanging)
            {
                HangingPlayer();
            }
            else if (canJump && !isHanging) // �ߺ� ���� ����
            {
                playerRigid.velocity = new Vector2(playerRigid.velocity.x, 0);
                playerRigid.AddForce(Vector2.up * playerData.jumpPower * bonusPow);
                jump++;
                if (isHanging) { HangingOver(); }
                isJump = true;
                Sound("Jump");
            }
            else if (canJump && isHanging)
            {
                playerRigid.velocity = movedirection * playerData.moveSpeed;
                playerRigid.AddForce(Vector2.up * playerData.jumpPower * bonusPow);
                jump++;
                if (isHanging) { HangingOver(); }
                isJump = true;
                Sound("Jump");
            }
        }
    }
    public void Damaged(Transform collisionObj)
    {
        if (canDamaged)
        {
            --playerData.maxHP;
            Rigidbody2D objRigid = gameObject.GetComponent<Rigidbody2D>(); // ������Ʈ ���� ����
            float direction = gameObject.transform.position.x - collisionObj.position.x; // �� ������Ʈ ����(2D)
            if (direction > 0) { direction = 1; }
            else { direction = -1; }
            objRigid.AddForce(new Vector2(damagedData.knockBack * direction, 0)); // �浹 �� �ݴ� ���� �˹�
            canCtrl = false; // �з����� ���� ��Ʈ�� ��Ȱ��ȭ
            StartCoroutine(DamagedDelay()); // ������ ������ Ȱ��ȭ
            gameObject.GetComponent<PlayerImage>().DamagedImageCo((int)playerData.damagedTime);
            if (playerData.maxHP <= 0) { PlayerDeath(); }
            Sound("Hit");
        }
    }
    public void CanCtrl() // �浹 �� ��Ʈ�� �ٽ� Ȱ��ȭ
    {
        timer += Time.deltaTime;
        if (timer > damagedData.knockBackTime)
        {
            canCtrl = true;
            timer = 0;
        }
    }
    public void HangingPlayer()
    {
        Vector3 Ypos = gameObject.transform.position;
        Ypos.y = nowCollisionObj.position.y;
        gameObject.transform.position = new Vector3(transform.position.x, Ypos.y, transform.position.z);
        playerRigid.constraints = RigidbodyConstraints2D.FreezePositionY;
        isHanging = true;
        jump = 0;
        playerRigid.velocity = new Vector2(0, 0);
    }
    public void HangingOver()
    {
        playerRigid.constraints = RigidbodyConstraints2D.None;
        playerRigid.constraints = RigidbodyConstraints2D.FreezeRotation;
        isHanging = false;
    }
    public void JumpOver() { jump = 0; isJump = false; }
    public void Jumpping() { isJump = true; }
    public void PlayerDeath()
    {
        GameObject.Instantiate(death, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        SceneData.S_instance.FailedUi("failed");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        nowCollisionObj = collision.transform;
        if (collision.CompareTag("Enemy")) { Damaged(collision.transform); } // �浹 �� ������ �Լ� ȣ��
        CanHanging = collision.CompareTag("Hanging") ? true : false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        nowCollisionObj = null;
        CanHanging = false;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        nowCollisionObj = collision.transform;
        if (collision.gameObject.CompareTag("DangerGround")) { Damaged(collision.transform); }
    }    
    IEnumerator DamagedDelay() // ������ �ڷ�ƾ
    {
        if (canDamaged)
        {
            canDamaged = false;
            StartCoroutine(TimeDelay());
        }
        else
        { canDamaged = true; }
        yield return null;
    }
    IEnumerator TimeDelay() // ���� �ð�
    {
        yield return new WaitForSeconds(damagedData.damagedTime);
        StartCoroutine(DamagedDelay());
    }
    void Sound(string move)
    {

        switch (move)
        {
            case "Jump":
                audio.clip = audioClipList[0];
                audio.volume = 0.5f;
                audio.Play();
                break;
            case "Hit":
                audio.clip = audioClipList[1];
                audio.volume = 1.0f;
                audio.Play();
                break;
        }

    }
}

