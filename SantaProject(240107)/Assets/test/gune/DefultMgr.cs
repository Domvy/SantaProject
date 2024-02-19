using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GData //**다형성의 포괄적인 의미->상황에 따라 형태가 정의변화 예)총: 기본총/기관총...
{
    public float delaytime;
    public int maxBullet;
    public string infor;
    public string soundeffect;
    public GameObject bullet;
}
//추상 클레스로 만듬 (데이터를 상속해야함 -> 추상클레스로 만듬)**추상화 부모를 재사용할수있게 /
public abstract class DefultMgr : MonoBehaviour
{
    // 공통적인 요건들 선언( 기본(부모 격 데이터) 각자 건들(자식) 사용할 )
    public GData gdata;//**캡슐화 함

    bool shout = true;
    float resrttime = 0;

    //기능 선언
    public abstract void Initsetting();//추상함수이기에 이름만 사용할수잇다 (상속) 구현 할수 없다

    //기본기능 선언
    public virtual void Using(Transform tip,TextMesh sound)//총구의 위치 
        //가상 함수 virtual부모클레스에서 정의된 메서들 자식클래스에서 재정의 overriding 접근 한정자 public, internal, protected사용
    {
        if(Input.GetKey(KeyCode.Space)&&shout)
        {
            var bull = Instantiate(gdata.bullet);
            bull.transform.position = tip.position;

            var effect = Instantiate(sound);//글자 위G
            effect.transform.position = tip.position + new Vector3(0, 1f, 0);
            effect.text = gdata.soundeffect;

            shout = false;
            gdata.maxBullet--;
        }

        if(shout==false)//각총의 지연 시간 설/
        {
            resrttime += Time.deltaTime;
            if(resrttime>=gdata.delaytime)
            {
                shout = true;
                resrttime = 0f;
            }
        }
    }
    
}
