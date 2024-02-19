using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] int speed, damage;

    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        damage = 1;
        Invoke("DestroyBullet", 2);
    }

    // Update is called once per frame
    void Update()
    {
        //if (transform.parent.CompareTag("Player1"))
        //{
        //    transform.Translate(transform.right * speed * Time.deltaTime);
        //}
        //else
        //{
        //    transform.Translate(transform.right  * speed * Time.deltaTime);
        //}
        transform.Translate(transform.right * speed * Time.deltaTime);
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (transform.parent == null && collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if ( collision.CompareTag("Player1"))
        {
            Destroy(gameObject);
            collision.GetComponent<PlayerController>().TakeDamage(damage);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

