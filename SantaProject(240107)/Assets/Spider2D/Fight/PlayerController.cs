
#region 이전
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.InputSystem;

//public class PlayerController : MonoBehaviour
//{
//    [SerializeField] StagerData stagdata;

//    private Vector2 movedirestion;
//    [SerializeField]
//    float movespeed, cooltime;
//    float curtime;
//    [SerializeField] Transform ballPosition;
//    [SerializeField] GameObject snowball;

//    public Animator animator;
//    AudioSource audio;
//    public List<AudioClip> audioClips = new List<AudioClip>();
//    //private Vector2 move;

//    int MaxHP = 6;
//    public static int currentHP;
//    SpriteRenderer SR;
//    [SerializeField] Sprite Throw, S_Hit, S_Die, S_rigin;
//    private void Awake()
//    {
//        currentHP = MaxHP;
//        SR = GetComponent<SpriteRenderer>();
//        animator = GetComponent<Animator>();
//        audio = GetComponent<AudioSource>();
//    }
//    // Update is called once per frame
//    //void Update()
//    //{
//    //    curtime -= Time.deltaTime;

//    //    bool hascontrol = (movedirestion != Vector2.zero);
//    //    if (hascontrol)
//    //    {

//    //        //뒷걸음으로 좌우 이미지가 달라질 필요 없

//    //        var x = Input.GetAxisRaw("Horizontal");
//    //        var y = Input.GetAxisRaw("Vertical");

//    //        //movedirestion = (Vector3.up * y) + (Vector3.right * x);
//    //       // movedirestion = (Vector3.up * y);
//    //        transform.Translate(new Vector2(x, y) * movespeed * Time.deltaTime);
//    //        transform.position = new Vector2(Mathf.Clamp(transform.position.x, stagdata.LimitMin.x, stagdata.LimitMax.x),
//    //       Mathf.Clamp(transform.position.y, stagdata.LimitMin.y, stagdata.LimitMax.y));
//    //    }

//    //    //Debug.Log(transform.position);
//    //}


//    //public void OnMove(InputValue value)
//    //{

//    //    Vector2 input = value.Get<Vector2>();
//    //    if (input != null)
//    //    {
//    //        movedirestion = new Vector2(input.x, input.y);
//    //        Debug.Log(movedirestion);
//    //    }
//    //}
//    bool isMove = false;
//    private void Update()
//    {
//        curtime -= Time.deltaTime;

//        // 이동 실행
//        isMove = (movedirestion != Vector2.zero && movedirestion.x == default);
//            if (isMove)
//            {
//                gameObject.transform.Translate(movedirestion * movespeed * Time.deltaTime);
//            }
//            transform.position = new Vector2(Mathf.Clamp(transform.position.x, stagdata.LimitMin.x, stagdata.LimitMax.x),
//            Mathf.Clamp(transform.position.y, stagdata.LimitMin.y, stagdata.LimitMax.y));
//    }

//    public void OnMove(InputValue value) // Input System 이동 함수
//    {
//        movedirestion = value.Get<Vector2>();
//    }
//    public void TakeDamage(int damage)
//    {
//        currentHP -= damage;
//        StopCoroutine("HitcolorAnimation");
//        StartCoroutine("HitcolorAnimation");

//        if (currentHP <= 0)
//        {
//            Ondie();
//        }
//        else
//        {
//            audio.clip = audioClips[0];
//            audio.Play();
//        }
//    }

//    IEnumerator HitcolorAnimation()
//    {
//        animator.SetTrigger("hit");
//        yield return new WaitForSeconds(0.5f);

//       animator.SetTrigger("idle");
//    }

//    private void Ondie()
//    {
//        animator.SetTrigger("die");
//        audio.clip = audioClips[1];
//        audio.Play();
//        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.snat_die")&&animator.GetCurrentAnimatorStateInfo(0).normalizedTime>=1f)
//        {
//            print("die");
//            SceneData.S_instance.FailedUi("failed");

//            Time.timeScale = 0;
//        }
//    }


//    private void OnJump()
//    {
//        if (curtime <= 0)
//        {
//            animator.SetBool("ismove", true);
//            StartCoroutine(Hitball());

//            curtime = cooltime;
//        }

//    }


//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        int damage = 1;
//        string Mtag = collision.tag;

//        switch (Mtag)
//        {
//            case ("Enemy"):
//                TakeDamage(damage);
//                break;

//            case ("Bonus"):
//                Destroy(collision.gameObject);
//                currentHP++;
//                break;
//        }

//    }

//    IEnumerator Hitball()
//    {
//        yield return new WaitForSeconds(0.2f);
//        Instantiate(snowball, ballPosition.position, transform.rotation);
//        animator.SetBool("ismove", false);
//    }
//}
#endregion

#region 이후
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] StagerData stagdata;

    [SerializeField]
    float movespeed, cooltime;
    float curtime;
    [SerializeField] Transform ballPosition;
    [SerializeField] GameObject snowball;

    public Animator animator;
    AudioSource audio;
    public List<AudioClip> audioClips = new List<AudioClip>();

    int MaxHP = 6;
    public static int currentHP;
    SpriteRenderer SR;
    [SerializeField] Sprite Throw, S_Hit, S_Die, S_rigin;

   // public GameObject obj;
    Touch ntouch;
    Vector3 nowPos, movePosDiff, prePos;
    public Camera cam;
    private void Awake()
    {
        currentHP = MaxHP;
        SR = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }
   
    bool isMove = false;
    private void Update()
    {
        curtime -= Time.deltaTime;

        if (Input.touchCount > 0)
        {
            ntouch = Input.GetTouch(0);
            Ray2D ray = new Ray2D(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            Debug.Log("ray" + ray);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            Debug.Log(hit.point);
            if (ntouch.phase == TouchPhase.Began && hit.collider != null && hit.collider.name == "JumpButton")
            {
                OnJump();
            }
            if (ntouch.phase == TouchPhase.Moved)
            {
                if (hit.collider == null)
                {
                    movePosDiff = Camera.main.ScreenToWorldPoint(ntouch.position);
                    transform.position = new Vector3(movePosDiff.x, movePosDiff.y, 0);
                }
            }
        }
    }

  
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        StopCoroutine("HitcolorAnimation");
        StartCoroutine("HitcolorAnimation");

        if (currentHP <= 0)
        {
            Ondie();
        }
        else
        {
            audio.clip = audioClips[0];
            audio.Play();
        }
    }

    IEnumerator HitcolorAnimation()
    {
        animator.SetTrigger("hit");
        yield return new WaitForSeconds(0.5f);

        animator.SetTrigger("idle");
    }

    private void Ondie()
    {
        animator.SetTrigger("die");
        audio.clip = audioClips[1];
        audio.Play();
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.snat_die") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            print("die");
            SceneData.S_instance.FailedUi("failed");

            Time.timeScale = 0;
        }
    }


    private void OnJump()
    {
        if (curtime <= 0)
        {
            animator.SetBool("ismove", true);
            StartCoroutine(Hitball());

            curtime = cooltime;
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        int damage = 1;
        string Mtag = collision.tag;

        switch (Mtag)
        {
            case ("Enemy"):
                TakeDamage(damage);
                break;

            case ("Bonus"):
                Destroy(collision.gameObject);
                currentHP++;
                break;
        }

    }

    IEnumerator Hitball()
    {
        yield return new WaitForSeconds(0.2f);
        Instantiate(snowball, ballPosition.position, transform.rotation);
        animator.SetBool("ismove", false);
    }
}
#endregion