using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeveCtrl : MonoBehaviour
{


    public GameObject emu;

    //int icount = 10;
    //public BoxCollider2D area;
    //private List<GameObject> emulist = new List<GameObject>();

    //// Start is called before the first frame update
    //void Start()
    //{
    //    area = GetComponent<BoxCollider2D>();
    //    StartCoroutine("Spawn", 2);
    //}

    ////// Update is called once per frame
    ////void Update()
    ////{

    ////}

    //IEnumerator Spawn(float delaytime)
    //{
    //    for (int i = 0; i < icount; i++)
    //    {
    //        Vector3 spawnpos = Getrandomposition();
    //        GameObject instance = Instantiate(emu, spawnpos, Quaternion.identity);
    //        emulist.Add(instance);
    //    }
    //    area.enabled = false;
    //    yield return new WaitForSeconds(delaytime);
    //    for (int i = 0; i < icount; i++)
    //    {
    //        Destroy(emulist[i].gameObject);

    //    }
    //    emulist.Clear();
    //    area.enabled = true;
    //    StartCoroutine("Spawn", 2);

    //}
    //private Vector2 Getrandomposition()
    //{
    //    Vector2 basePosition = transform.position;
    //    Vector2 size = area.size;
    //    float posX = basePosition.x + Random.Range(-size.x/2f, size.x / 2f);
    //    float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);

    //    Vector2 spawnpos = new Vector2(posX, posY);
    //    return spawnpos;
    //}
    //----------------------------------------------------------------
    //float currTime;

    //// 반복되는 작업이므로 업데이트 함수 안에서 코드를 입력한다.
    //void Update()
    //{
    //    // 시간이 흐르게 만들어준다.
    //    currTime += Time.deltaTime;

    //    // 오브젝트를 몇초마다 생성할 것인지 조건문으로 만든다. 여기서는 10초로 했다.
    //    if (currTime > 1)
    //    {
    //        // x,y,z 좌표값을 각각 다른 범위에서 랜덤하게 정해지도록 만들었다.
    //        //float newX = Random.Range(-10f, 10f), newY = Random.Range(-50f, 50f), newZ = Random.Range(-100f, 100f);

    //        // 생성할 오브젝트를 불러온다.
    //        GameObject monster = Instantiate(emu);

    //        // 불러온 오브젝트를 랜덤하게 생성한 좌표값으로 위치를 옮긴다.
    //        emu.transform.position = Getrandomposition();

    //        // 시간을 0으로 되돌려주면, 10초마다 반복된다.
    //        currTime = 0;
    //    }
    //}
    //private Vector2 Getrandomposition()
    //{
    //    Vector2 basePosition = transform.position;
    //    Vector2 size = area.size;
    //    float posX = basePosition.x + Random.Range(-size.x/2f, size.x / 2f);
    //    float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);

    //    Vector2 spawnpos = new Vector2(posX, posY);
    //    return spawnpos;
    //}

    public float spRangeX = 20f;
    public float spRangeY = 20f;

    private void Start()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spRangeX, spRangeX),spRangeY, 0);
        Instantiate(emu, spawnPos, emu.transform.rotation);
    }


}
