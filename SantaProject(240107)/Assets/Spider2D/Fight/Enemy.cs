using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int MaxHP = 2;
    int currentHP;
   
    Animator animator;
    AudioSource audio;
    
    [SerializeField] GameObject[] explosionObj;
    [SerializeField] float cooltime, curtime;

    [SerializeField] GameObject snowball;
    [SerializeField] Transform ballPosition;

    bool on;
    Move2D move2D;
    private void Awake()
    {
        currentHP = MaxHP;
        
        move2D = GetComponent<Move2D>();
        animator = GetComponent<Animator>();
        curtime = cooltime;
        audio = GetComponent<AudioSource>();
    }

   
    private void Update()
    {
        curtime -= Time.deltaTime;
        if (curtime <= 0)
        {
            StartCoroutine("ThrowV");
           
        }
    }
   
    IEnumerator ThrowV()
    {
        animator.SetTrigger("throw");
        yield return new WaitForFixedUpdate();

        if (ballPosition.transform.childCount == 0 || snowball == null)
        {
            Instantiate(snowball, ballPosition.position, transform.rotation, ballPosition);
        }
        curtime = cooltime;

    }
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        StopCoroutine("HitcolorAnimation");
        StartCoroutine("HitcolorAnimation");

        if (currentHP <= 0)
        {
            StopCoroutine("ThrowV");
            StartCoroutine("V_dieOn");
        }
        audio.Play();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            Destroy(gameObject);

        }
    }

    IEnumerator HitcolorAnimation()
    {
        animator.SetTrigger("hit");
        yield return new WaitForSeconds(1f);
      
    }

    IEnumerator V_dieOn()
    {
        
        move2D.moveSpeed = 0;
        SpawnItem();
        animator.SetTrigger("die");
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
    }
  

    private void SpawnItem()
    {
        int spawnItem = Random.Range(0, 50);
        if (spawnItem < 10)
        { Instantiate(explosionObj[0], transform.position, Quaternion.identity); }
    }
}
