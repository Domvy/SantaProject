using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cad_mgr : MonoBehaviour
{
    public bool facedup, locked;
    public static bool coroutineallowed;

    private Cad_mgr firstinpair, secondinpair;
    private string fistinpairName, secondinpaieName;

    public static Queue<Cad_mgr> sequence;
    public static int pairsFound;

    
    public Image rend;
    public Sprite faceSp;
    [SerializeField]
    private Sprite backSp;

    private BoxCollider2D collider=new BoxCollider2D();

    RetunCad retunCad;
   
    // Start is called before the first frame update
    void Start()
    {
        retunCad = GameObject.Find("mgr").GetComponent<RetunCad>();
      
        collider = GetComponent<BoxCollider2D>();
        int boxcolliderSizeX=200;
        int boxcolliderSizey = 300;
        collider.size = new Vector2(boxcolliderSizeX, boxcolliderSizey);
        facedup = false;
        coroutineallowed = true;
        locked= false;
        sequence = new Queue<Cad_mgr>();
        pairsFound = 0;

        rend = GetComponent<Image>();
        faceSp = gameObject.GetComponent<Image>().sprite;

       
        StartCoroutine(Setting_Card());
    }
   

    private void OnMouseDown()
    {
        
        if (!locked && coroutineallowed) { print(locked); StartCoroutine(RotateCard()); }
    }

    IEnumerator Setting_Card()
    {
        coroutineallowed = false;
        float settingRetuntime = 3f;
        yield return new WaitForSeconds(settingRetuntime);
        for (float i = -180f; i <= 0f; i += 10f)
        {
            if (i == -90f)
            {
                rend.sprite = backSp;
            }
            transform.rotation = Quaternion.Euler(0f, i, 0f);
            yield return new WaitForSeconds(0f);
            sequence.Clear();
        }
        retunCad.AudioPlay(2);
        coroutineallowed = true;

    }

    IEnumerator RotateCard()
    {
        coroutineallowed = false;
        retunCad.AudioPlay(0);
        if(!facedup)
        {
            sequence.Enqueue(this);
            for (float i = 0; i <= 180f; i += 10f)
            {   if (i == 90f)
                {

                    rend.sprite = faceSp;
                }
           
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                yield return new WaitForSeconds(0f);
            }
        }

        else if(facedup)
        {
            for (float i = 180f; i >= 0f; i -= 10f)
            {
                if (i ==90f)
                {
                    rend.sprite = backSp;
                }
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                yield return new WaitForSeconds(0f);
                sequence.Clear();
            }
        }
        coroutineallowed = true;
        facedup = !facedup;
        if(sequence.Count==2)
        {
            CheckResults();
        }
    }
    private void CheckResults()
    {
        firstinpair = sequence.Dequeue();
        secondinpair = sequence.Dequeue();

        fistinpairName = firstinpair.gameObject.GetComponent<Image>().sprite.name;
        secondinpaieName = secondinpair.gameObject.GetComponent<Image>().sprite.name;

       

        if (fistinpairName==secondinpaieName)
        {
            firstinpair.locked = true;
            secondinpair.locked = true;
            pairsFound += 1;
            retunCad.AudioPlay(2);
        }
        else
        {
            firstinpair.StartCoroutine("RotateBack");
            secondinpair.StartCoroutine("RotateBack");
        }
        if(pairsFound==6)
        {
            SceneData.S_instance.MissionCrear("crear");
            Time.timeScale = 0;
        }
    }
    public IEnumerator RotateBack()
    {
        coroutineallowed = false;
        retunCad.AudioPlay(1);
        float rotateTime = 0.2f;
        yield return new WaitForSeconds(rotateTime);
        for (float i = 180f; i >= 0f; i -= 10f)
        {
            if (i == 90f)
            {
                rend.sprite = backSp;
            }
            transform.rotation = Quaternion.Euler(0f, i, 0f);
            yield return new WaitForSeconds(0f);
            sequence.Clear();
        }
        facedup = false;
        coroutineallowed = true;
    }
}
