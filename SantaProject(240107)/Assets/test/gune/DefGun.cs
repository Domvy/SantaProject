using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//각 무기별로 무기매니저를 상속 받는다(기능만상속: 데이터 관련이 아)
public class DefGun : DefultMgr
{
    public override void Initsetting()//기본세팅 상속정읭** 상속 재사용 정의
    {
        gdata.delaytime = 1f;
        gdata.infor = "기본건총";
        gdata.soundeffect = "빵야";
        gdata.maxBullet = -1;
        gdata.bullet = Resources.Load<GameObject>("defbellet");
    }
    public override void Using(Transform tip, TextMesh sound)
    {
        base.Using(tip, sound);
    }
}
