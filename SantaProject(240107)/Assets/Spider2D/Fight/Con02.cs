using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Con02 : MonoBehaviour
{
    [SerializeField] Text score;

    [SerializeField] float maxTime;
    float timeleft;
    [SerializeField] Image timerBar;
    [SerializeField] Image[] PosH;
    [SerializeField] Sprite full_H, end_H;
    [SerializeField] GameObject heart;
    bool off;

    int Hp;
    // Start is called before the first frame update
    void Start()
    {
        timeleft = maxTime;   
    }

    // Update is called once per frame
    void Update()
    {
        //score.text = PlayerController.currentHP.ToString();
        
        if (!off)
        {
            if (timeleft > 0)
            {
                timeleft -= Time.deltaTime;
                timerBar.fillAmount = timeleft / maxTime;
            }
            else
            {

                SceneData.S_instance.MissionCrear("crear");
                off = !off;
              
            }

            
        }
        if (!off)
        {
            Hp = PlayerController.currentHP;
            foreach (Image img in PosH)
            {
                img.sprite = end_H;
            }
            for (int i = 0; i < Hp; i++)
            {

                PosH[i].sprite = full_H;
            }
            if(Hp==0)
            {
                SceneData.S_instance.FailedUi("failed");
                Debug.Log("ui");
                off = !off;
            }
        }
       

    }


}
