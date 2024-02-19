using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamMgr : MonoBehaviour
{
    AudioSource audio;
    public AudioClip audioClip;

    [SerializeField] GameObject[] Socks;
    int score;
   // [SerializeField] Text score;
    bool on;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audioClip = Resources.Load<AudioClip>("Present");
   }
    // Update is called once per frame
   public void SoundPlay()
    {
        audio.PlayOneShot(audioClip);
    }
    private void Update()
    {
        score = +SocksMgr.add;
       
        if (!on)
        {
            if (score == Socks.Length)
            {
               
                StartCoroutine("Waiting");
                on= !on;
               
            }
        }
        
    }

   IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1f);
        SceneData.S_instance.MissionCrear("crear");
    }
}
