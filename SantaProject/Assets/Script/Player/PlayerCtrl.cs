using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UserDatabase;

public class PlayerCtrl : MonoBehaviour
{
    public Data playerData; // 기본 데이터 컨테이너
    public Data damagedData;
    public GameObject death;
    private Vector2 movedirection; // 이동 방향
    private bool canCtrl; // 조작 활성화
    public bool isMove; // 이동
    public bool isJump; // 점프
    public bool isHanging; // 매달리기
    public bool canJump; // 점프 활성화
    [SerializeField]
    private bool CanHanging; // 매달리기 활성화    
    public bool canDamaged; // 데미지 활성화
    private int bonusPow; // 점프 파워 보정
    private int jump; // 점프 횟수 카운트
    private float timer; // 이동 불가 타이머
    private Transform nowCollisionObj;
    private Rigidbody2D playerRigid;
    private Collider2D bootsCollider;
    AudioSource audio;
    public List<AudioClip> audioClipList;

    private void Start()
    {
        //기본 플레이어 클래스 선언
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
            // 이동 실행
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
            // 점프 실행
            if (playerData.jumpCount == jump) { canJump = false; }
            else { canJump = true; }
        }
        if (!canCtrl) { CanCtrl(); }
        if (!CanHanging) { if (isHanging) { HangingOver(); } }
    }
    public void OnMove(InputValue value) // Input System 이동 함수
    {
        movedirection = value.Get<Vector2>();
        gameObject.GetComponent<PlayerImage>().FlipImage(movedirection.x);
    }
    void OnJump() // Input System 점프 함수
    {
        if (canCtrl)
        {
            if (CanHanging && !isHanging)
            {
                HangingPlayer();
            }
            else if (canJump && !isHanging) // 중복 점프 방지
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
            Rigidbody2D objRigid = gameObject.GetComponent<Rigidbody2D>(); // 오브젝트 물리 변수
            float direction = gameObject.transform.position.x - collisionObj.position.x; // 적 오브젝트 방향(2D)
            if (direction > 0) { direction = 1; }
            else { direction = -1; }
            objRigid.AddForce(new Vector2(damagedData.knockBack * direction, 0)); // 충돌 시 반대 방향 넉백
            canCtrl = false; // 밀려나는 동안 컨트롤 비활성화
            StartCoroutine(DamagedDelay()); // 데미지 딜레이 활성화
            gameObject.GetComponent<PlayerImage>().DamagedImageCo((int)playerData.damagedTime);
            if (playerData.maxHP <= 0) { PlayerDeath(); }
            Sound("Hit");
        }
    }
    public void CanCtrl() // 충돌 후 컨트롤 다시 활성화
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
        if (collision.CompareTag("Enemy")) { Damaged(collision.transform); } // 충돌 시 데미지 함수 호출
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
    IEnumerator DamagedDelay() // 데미지 코루틴
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
    IEnumerator TimeDelay() // 무적 시간
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

