using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] StagerData stagdata;
    
    [SerializeField] int enemyconut;
    [SerializeField] GameObject enemy_F;
    [SerializeField] float spawnTime;
    Rigidbody2D rd2d;
    Transform target;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnEnemy");
    }

    

    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            float positiony = Random.Range(stagdata.LimitMin.y, stagdata.LimitMax.y);
            Instantiate(enemy_F, new Vector3( stagdata.LimitMax.x + 1.0f, positiony, 0f), Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
