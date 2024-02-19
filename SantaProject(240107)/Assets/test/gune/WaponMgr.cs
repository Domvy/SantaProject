using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 총을 쏘는 방
public class WaponMgr : MonoBehaviour
{
    public DefultMgr mymgr;//선언 사용할수있게 한다

    public Transform tip;
    public TextMesh sound;
    // Start is called before the first frame update
    void Start()
    {
        mymgr.Initsetting();//세팅을 먼저해주
    }

    // Update is called once per frame
    void Update()
    {
        mymgr.Using(tip,sound);
    }
}
