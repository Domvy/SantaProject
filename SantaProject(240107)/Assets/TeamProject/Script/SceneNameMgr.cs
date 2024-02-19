using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneNameMgr : MonoBehaviour
{
    private static SceneNameMgr mgr;
    public static SceneNameMgr Mgr
    {
        get
        {
            if(mgr==null)
            {
                return null;
            }
            return mgr;
        }
    }

    private void Awake()
    {
        if(mgr==null)
        {
            mgr = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else { Destroy(this.gameObject); }
      
    }
    // Start is called before the first frame update
    void Start()
    {
        SceneData.S_instance.SceneName = SceneManager.GetActiveScene().name;
        print(SceneData.S_instance.SceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
