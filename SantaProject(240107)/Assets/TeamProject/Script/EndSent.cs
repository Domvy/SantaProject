using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSent : MonoBehaviour
{
    //본게임 스테이지 1,2,3에 EndPoint/Endstage에 넣어사용 StartCoroutine(Endpoint());
    public IEnumerator Endpoint()
    {
        yield return new WaitForSeconds(2f);
        SceneData.S_instance.MissionCrear("crear");
    }
}
