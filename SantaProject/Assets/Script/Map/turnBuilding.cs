using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.XR.Oculus.Input;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;

public class turnBuilding : MonoBehaviour
{
    int speed = 1;
    int angle = 90;
    [SerializeField]
    int bc = 0;
    int before = 0;
    float delayTime = 3f;
    bool isRunning = false;
    [SerializeField]
    bool delay = false;
    [SerializeField]
    List<GameObject> turnPos = new List<GameObject>();
    GameObject player = null;
    Rigidbody2D rb;
    PlayerInput input;
    GameObject movePos;
    private delegate void RunDelegate(bool angle); // 회전 메서드 실행
    public GameObject[] cube = new GameObject[4];


    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
        input = player.GetComponent<PlayerInput>();
        turnPos.AddRange(GameObject.FindGameObjectsWithTag("TurnPos"));
    }
    private void Start()
    {
        for (int i = 0; i < cube.Length; i++)
        {
            if (i != 0)
            {
                cube[i].SetActive(false);
            }
        }
    }
    #region 회전 시작
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == player && rb.constraints == RigidbodyConstraints2D.FreezeRotation)
        {
            for (int i = 0; i < turnPos.Count; i++)
            {
                if (Math.Abs(player.transform.position.x - turnPos[i].transform.position.x) < 0.1f && !delay)
                {
                    bool angle = this.transform.position.x - turnPos[i].transform.position.x  < 0 ? true : false;
                    movePos = turnPos[i];
                    if (Mathf.Abs(movePos.transform.position.z - player.transform.position.z) < 0.1f)
                    {
                        RunDelegate turnAround = Turn;
                        turnAround += FixPlayer;
                        turnAround(angle);
                        break;
                    }                    
                }
            }
        }
    }
    #endregion
    #region 회전 실행
    private void Turn(bool angle) // 건물 회전 실행
    {
        before = bc;
        bc = angle ? bc != 3 ? ++bc : 0 : bc != 0 ? --bc : 3;        
        StartCoroutine(TurnBuilding(angle ? 90 : -90));
    }
    IEnumerator TurnBuilding(float angle) // 회전 방향 코루틴
    {
        isRunning = true;
        cube[bc].SetActive(true);
        float rot = 0;
        Vector3 direction;
        direction = angle == 90 ? Vector3.up : Vector3.down;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        input.enabled = false;
        while (rot < Math.Abs(angle))
        {
            rot += speed;
            this.gameObject.transform.Rotate(direction * speed);
            yield return new WaitForSeconds(0.01f);
        }
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        input.enabled = true;
        rot = 0;        
        cube[before].SetActive(false);
        isRunning = false;      
        StartCoroutine(Delay());
    }
    #endregion
    #region 플레이어 위치이동
    private void FixPlayer(bool angle)
    {
        StartCoroutine(MovePlayer(angle ? -1 : 1));
    }
    IEnumerator MovePlayer(float angle)
    {
        player.GetComponent<BoxCollider2D>().enabled = false;
        Vector3 vector;
        while (isRunning)
        {            
            vector = player.transform.position;
            vector.x = movePos.transform.position.x;
            vector.z = movePos.transform.position.z;
            player.transform.position = vector;
            yield return new WaitForSeconds(0.01f);
        }
        vector = player.transform.position;
        vector.z = 0;
        player.transform.position = vector;
        player.GetComponent<BoxCollider2D>().enabled = true;
    }
    #endregion
    IEnumerator Delay()
    {
        delay = true;
        float time = 0;
        while (time < delayTime)  
        {
            time += 0.1f;
            yield return new WaitForSeconds(0.1f);            
        }
        delay = false;
    }
}
