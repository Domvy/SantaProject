using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSent : MonoBehaviour
{
    //������ �������� 1,2,3�� EndPoint/Endstage�� �־��� StartCoroutine(Endpoint());
    public IEnumerator Endpoint()
    {
        yield return new WaitForSeconds(2f);
        SceneData.S_instance.MissionCrear("crear");
    }
}
