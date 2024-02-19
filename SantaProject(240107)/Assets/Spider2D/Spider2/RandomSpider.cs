using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.UI;



public class RandomSpider : MonoBehaviour
{
    [Tooltip("기준점수")]
    public static int r_score;
    [Tooltip("거미프리팹")]
    public GameObject[] spider;

   
    [Tooltip("진행 시간")]
    public float time;

    public static int No_score;
    [SerializeField] int max;


    //static public List<string> objList = new List<string>();
    public AudioSource audio;
    public AudioClip[] clip=new AudioClip[2];
    bool on;
   public static bool up;

    public Text M_score;

    public static System.Action<int> target;

    public Transform[] pos;
    public Spidermager spidermager;

    [SerializeField] float maxTime;
    float timeleft;
    [SerializeField] Image timerBar;
    private void Awake()
    {
        up = false;
        target = AudioPlay;
        timeleft = maxTime;
    }
    private void OnEnable()
    {
        audio = GetComponent<AudioSource>();
        StartCoroutine("Spawn", time);

    }
    private IEnumerator Spawn(float time)
    {
        if (!on)
        {
         yield return new WaitForSeconds(time);
            
            int IPOS = Random.Range(0, pos.Length);
        int randomIndex = Random.Range(0, spider.Length);
        
        GameObject instance = Instantiate(spider[randomIndex], pos[IPOS].position, Quaternion.identity);
            target(0);
            spidermager = instance.GetComponent<Spidermager>();
            spidermager.Insetting();
            up = !up;

            //objList.Add(instance.name); 
       
            StartCoroutine("DeSpawn", time);
        }
        

    }

    private IEnumerator DeSpawn(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine("Spawn", time);

    }

   

    private void Update()
    {

        if (!on)
        {
            M_score.text = max+"/"+ r_score.ToString();
            if (timeleft > 0)
            {
                timeleft -= Time.deltaTime;
                timerBar.fillAmount = timeleft / maxTime;
            }
            else
            {
                if (timeleft<= 0)
                {
                    SceneData.S_instance.FailedUi("failed");
                    on = !on;
                    r_score = 0;
                }
                Time.timeScale = 0;
            }

            if (r_score >= max)
            {
                SceneData.S_instance.MissionCrear("crear");
                on = !on;
                r_score = 0;
            }
           
        }
        if (up)
        {   
            spidermager.Using();
        }
   
    }

    public void AudioPlay(int i)
    {
        audio.clip = clip[i];

        audio.Play();
    }
    
}
   

