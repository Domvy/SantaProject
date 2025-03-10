using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayHitM : MonoBehaviour
{
    public string num;
    //현재 번호와 기계 이름이 같으면 가능
    public GameObject[] machine;
    float time = 0f;
    public float F_time = 1f;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(FadeOut_on());

        }
    }

    IEnumerator FadeOut_on()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        time = 0f;
        yield return new WaitForSeconds(0.5f);
        if (Physics.Raycast(ray, out hit))//마우스 포지션에 레이를 던져 정보 hit에 넣음
        {

            GameObject ma = hit.transform.gameObject;
            //애니메이션 플레이
            if (ma.name == num)
            {
                //자식까지 컬러빼기
               Transform[] myChildren = ma.GetComponentsInChildren<Transform>();

                foreach (Transform child in myChildren)
                {
                   Renderer re_ch = child.GetComponent<Renderer>();
                    Color alpha = re_ch.material.color;
                    
                    while (alpha.a > 0f)//알파값 빼기
                    {
                     
                        time += Time.deltaTime / F_time;
                        alpha.a = Mathf.Lerp(1, 0, time);
                        re_ch.material.color = alpha;
                        yield return null;
                    }

                    yield return null;
                }
            }
            else
            {
                for (int i = 0; i < machine.Length; i++)
                {
                   Transform[] O_myChildren = machine[i].GetComponentsInChildren<Transform>();
                    foreach (Transform child in O_myChildren)
                    {
                        Renderer re_ch = child.GetComponent<Renderer>();
                       Color alpha = re_ch.material.color;
                        while (alpha.a < 1f)//알파값 빼기
                        {
                            time += Time.deltaTime / F_time;
                            alpha.a = Mathf.Lerp(0, 1, time);
                            re_ch.material.color = alpha;
                            yield return null;
                        }
                        yield return null;
                    }
                }
            }
        }
    }
}
    



     

 