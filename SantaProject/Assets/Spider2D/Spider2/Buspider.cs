using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Buspider : MonoBehaviour
//{
//    public float time=1f;
//    public int iscore = 5;
//    public ParticleSystem pt;
//    int i = 1;

//    // Start is called before the first frame update

//    private void Awake()
//    {
//        pt = transform.Find("pt").GetComponent<ParticleSystem>();
//        pt.Stop();
//    }
//    void Start()
//    {
//        Invoke("Destroy", time);
//    }

//   void Destroy()
//    {
//        Destroy(this.gameObject);
//    }

//    private void OnMouseDown()
//    {
//        RandomSpider.target(i);
//        Destroy(this.gameObject);
//        pt.Play();
//        RandomSpider.r_score += iscore;

//    }
//}
public class Buspider : Spidermager
{
    public override void Insetting()
    {
        sdata.time = 0.8f;
        sdata.iscore = 3;
        sdata.oudio = 1;
    }

    public override void Start()
    {
        base.Start();
    }
    public override void Using()
    {
        base.Using();
    }
}
