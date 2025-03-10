using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemyDatabase;

public class Birds : MonoBehaviour
{
    public EnemyData enemyData;
    public GameObject range;
    private float speed;
    private Vector3 targetVector;
    private bool attack;
    private SpriteRenderer renderer;
    void Start()
    {
        attack = false;
        speed = enemyData.sparrowMoveSpeed;
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (attack)
        {
            gameObject.transform.Translate(targetVector * speed / 5 * Time.deltaTime);
            if(targetVector.x > 0)
            {
                renderer.flipX = true;
            }
        }
    }
    public void FindTarget(Transform position)
    {
        Transform targetPos = position;
        targetVector = targetPos.transform.position - gameObject.transform.position;
        attack = true;
    }
}
