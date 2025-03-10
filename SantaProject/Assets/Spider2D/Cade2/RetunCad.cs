using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RetunCad : MonoBehaviour
{
    public List<GameObject> cad;
    public List<Sprite> SpriteList ;
    public List<Sprite> Re_cadSprite;
    public  Text wintext;
    AudioSource audio;
    public AudioClip[] clip;

    [SerializeField] float maxTime;
    [SerializeField]float timeleft;
    [SerializeField] Image timerBar;
    bool off;

    public int[] Randomnum(int maxcont, int n)
    {
        int[] defauts = new int[maxcont];
        int[] result = new int[n];
        for (int i = 0; i < maxcont; i++)
        {
            defauts[i] = i;
        }
        for (int i = 0; i < n; i++)
        {
            int index = Random.Range(0, maxcont);
            result[i] = defauts[index];
            defauts[index] = defauts[maxcont - 1];
            maxcont--;

        }
        return result;
    }

    private void Awake()
    {
        int[] num = Randomnum(12, 12);
        for (int i = 0; i < num.Length; i++)
        {
            int n = num[i];
            
            cad[i].GetComponent<Image>().sprite= SpriteList[n];
            Re_cadSprite.Add(cad[i].GetComponent<Image>().sprite);

        }
        audio = GetComponent<AudioSource>();

        timeleft = maxTime;
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if(timeleft>0)
        {
            timeleft -= Time.deltaTime;
            timerBar.fillAmount = timeleft / maxTime;
        }
        else
        {
            if(!off)
            {
                SceneData.S_instance.FailedUi("failed");
                off = !off;
            }
            
            Time.timeScale = 0;
        }
    }

    public void AudioPlay(int i)
    {
        audio.clip = clip[i];

        audio.Play();
    }

}
