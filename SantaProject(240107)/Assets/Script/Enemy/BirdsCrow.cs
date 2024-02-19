using EnemyDatabase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class BirdsCrow : MonoBehaviour
{
    public EnemyData enemyData;
    public GameObject range;
    private float speed;
    private SpriteRenderer renderer;
    private int moveNum;
    [SerializeField]
    float moverange = 0;
    private Animator animation;

    void Start()
    {
        speed = enemyData.crowMoveSpeed;
        renderer = gameObject.GetComponent<SpriteRenderer>();
        animation = gameObject.GetComponent<Animator>();
        moveNum = Random.Range(-1, 1) < 0 ? 1 : -1;

    }
    void Update()
    {
        gameObject.transform.Translate(new Vector2(moveNum, 0) * speed / 10 * Time.deltaTime);
        moverange += speed * Time.deltaTime;
        if (moveNum > 0) { renderer.flipX = true; }
        else { renderer.flipX = false; }
        if (moverange >= range.transform.localScale.x)
        {
            moveNum = moveNum == -1 ? 1 : -1;
            moverange = 0;
        }
    } 
}
