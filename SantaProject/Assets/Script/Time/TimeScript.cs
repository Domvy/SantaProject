using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimerPackage;
using UserDatabase;


namespace TimerPackage
{
    public class TimeScript : MonoBehaviour
    {
        public IEnumerator EntireTimer(float time)
        {
            time += 1;
            Debug.Log(time);
            yield return new WaitForSeconds(1.0f);
        }
    }
}

public class TimerMethod : MonoBehaviour
{
    public Data timerData; // 기본 데이터 컨테이너   
    TimeScript timeScript = new TimeScript();

    public void EnterTimerStart()
    {
        StartCoroutine(timeScript.EntireTimer(timerData.defaultTimer));
    }

    private void Start()
    {
        timerData = GameObject.FindWithTag("GameController").GetComponent<DataMgr>().data;
    }
}


