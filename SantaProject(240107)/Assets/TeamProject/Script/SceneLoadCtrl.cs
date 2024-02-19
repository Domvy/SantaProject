using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoadCtrl : MonoBehaviour
{
    bool isload;
    bool shoudload;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.sceneCount>0)
        {
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                if(scene.name==gameObject.name)
                {
                    isload = true;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadScene()
    {
        if(!isload)
        {
            SceneManager.LoadSceneAsync(gameObject.name, LoadSceneMode.Additive);
            isload = true;
        }
    }
    void UnLoadScene()
    {
        if(isload)
        {
            SceneManager.UnloadSceneAsync(gameObject.name);
            isload = false;
        }
    }

}

