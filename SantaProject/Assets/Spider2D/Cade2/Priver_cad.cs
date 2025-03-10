using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Priver_cad : MonoBehaviour
{

    
    public bool isactive, faceup;
    //public Image rend;
    public Button this_B;

    public Sprite faceSp;
    //public float x, y, z;
    public Sprite RfaceSp;
    [SerializeField]
    private Sprite backSp;
    [SerializeField]
    int timer;
    
    // Start is called before the first frame update
    void Start()
    {
        //rend = GetComponent<Image>();
        //faceSp =  gameObject.GetComponent<Image>().sprite;

        faceSp = GetComponent<SpriteRenderer>().sprite;

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnMouseDown()
    {
        StartCoroutine(CalculateFlip());
    }
    public void On_change()
    {

       StartCoroutine(CalculateFlip()); 

    }

    IEnumerator CalculateFlip()
    {



        isactive = false;
        if (!faceup)
        {
            Debug.Log(faceup);
            for (float i = 0; i >= -180f; i -= 10f)
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                
                if (i == 90f)
                {

                    faceSp= RfaceSp;
                }
                yield return new WaitForSeconds(0.01f);
                //transform.rotation = Quaternion.Euler(0f, 1f, 0f);

            }
        }

        else if (faceup)
        {
            transform.rotation = Quaternion.Euler(0f, 1f, 0f);
            for (float i = -180f; i <= 0f; i += 10f)
            {
                
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                
                if (i == -90f)
                {
                    faceSp = backSp;
                }
                yield return new WaitForSeconds(0.01f);
                
            }
        }
        isactive = true;

        faceup = !faceup;


    }
}
