using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainCtrl : MonoBehaviour
{
    AudioSource audio;
    private void Awake()
    {
        var obj = FindObjectsOfType<MainCtrl>();
        if(obj.Length==1 ) { DontDestroyOnLoad(gameObject);}
        else { Destroy(gameObject); }

        audio = gameObject.GetComponent<AudioSource>();
    }
    //private void Start()
    //{
    //    SceneData.S_instance.SceneName = SceneManager.GetActiveScene().name;
    //    Debug.Log(SceneData.S_instance.SceneName);
    //}
   void Update()
    {
        SceneData.S_instance.SceneName = SceneManager.GetActiveScene().name;

        if (Input.GetMouseButtonDown(0))
        {
            audio.Play();
        }
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                audio.Play();
            }
        }
    }
}
