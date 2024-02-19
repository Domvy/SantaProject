using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Yespider : Spidermager
{
    public override void Insetting()
    {
        sdata.time = 1.2f;
        sdata.iscore = 1;
        sdata.oudio = 1;
    }

    //public override void Start()
    //{
    //    base.Start();
    //}
    public override void Using()
    {
        base.Using();
    }
}