using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemyDatabase;

public class Dogs : MonoBehaviour
{
    public EnemyData enemyData;
    public GameObject range;
    private float speed;
    private Vector3 targetVector;
    private bool attack;
    private SpriteRenderer renderer;
    private int moveNum;
    private Animator dogAnimation;
    private AudioSource audio;

    void Start()
    {
        attack = false;
        speed = enemyData.dogMoveSpeed;
        renderer = gameObject.GetComponent<SpriteRenderer>();
        dogAnimation = gameObject.GetComponent<Animator>();
        audio = gameObject.GetComponent<AudioSource>();
        StartCoroutine(MoveNumReset());
    }
    void Update()
    {
        if (attack)
        {
            gameObject.transform.Translate(targetVector * speed / 5 * Time.deltaTime);
            if (targetVector.x > 0){renderer.flipX = true;}
            else { renderer.flipX = false; }
            dogAnimation.SetInteger("State", 3);
        }
        else if (!attack)
        {
            gameObject.transform.Translate(new Vector2(moveNum, 0) * speed / 10 * Time.deltaTime);
            if (moveNum > 0){renderer.flipX = true;}
            else { renderer.flipX = false; }
            dogAnimation.SetInteger("State", 2);
            if (moveNum == 0) { dogAnimation.SetInteger("State", 1); }
        }        
    }
    public void FindTarget(Transform position)
    {
        Transform targetPos = position;
        targetVector = targetPos.transform.position - gameObject.transform.position;
        targetVector.y = 0;
        attack = true;
    }
    public void MissTarget()
    {
        attack = false;
    }
    IEnumerator MoveNumReset()
    {
        while (!attack)
        {
            moveNum = Random.Range(-1, 2);                
            yield return new WaitForSeconds(5f);
        }
    }
    public void Sound()
    {
        audio.Play();
    }
}
