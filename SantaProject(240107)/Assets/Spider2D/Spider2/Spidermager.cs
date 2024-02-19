using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public struct Sdata
{
    public float time;
    public int iscore;
    public int oudio;
    
   
}

public abstract class Spidermager : MonoBehaviour
{
    public Sdata sdata;

    bool on;
    public abstract void Insetting();
   
   
    // Start is called before the first frame update
    public virtual void Start()
    {
       RandomSpider.up = true;
        StartCoroutine(Noget_Destroy());
    }

    IEnumerator Noget_Destroy()
    {
        yield return new WaitForSeconds(sdata.time);

        this.gameObject.SetActive(false);
        if(!on)
        {
            RandomSpider.No_score += 1;
            print(RandomSpider.No_score);
        }
       
    }

    void Destroy()
    {
        this.gameObject.SetActive(false);
        
    }

    public virtual void Using()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, transform.forward, 20f);
            if (hit.collider!=null)
            {
                print(hit.collider.name);
                RandomSpider.target(sdata.oudio);
                RandomSpider.r_score += sdata.iscore;
                on = !on;
                Destroy();
            }
            else
            {
                
                return;
            }
        }
    }

}
