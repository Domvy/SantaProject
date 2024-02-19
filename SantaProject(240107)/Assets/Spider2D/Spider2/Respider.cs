using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Respider : MonoBehaviour
//{
//    public float time = 1.5f;

//    public int iscore = 2;
//    int i = 1;


//    // Start is called before the first frame update
//    void Start()
//    {
//        Invoke("Destroy", time);
//    }


//    void Destroy()
//    {
//        Destroy(this.gameObject);
//    }

//    private void OnMouseDown()
//    {
//        RandomSpider.target(i);
//        Destroy(this.gameObject);
//        RandomSpider.r_score += iscore;
//    }

//}
public class Respider : Spidermager
{
    public override void Insetting()
    {
        sdata.time = 1f;
        sdata.iscore = 2;
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