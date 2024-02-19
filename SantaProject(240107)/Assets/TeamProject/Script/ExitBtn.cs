using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UserDatabase;

public class ExitBtn : MonoBehaviour
{
    public Data damagedData;

    private static ExitBtn mgr;
    public static ExitBtn Mgr
    {
        get
        {
            if (mgr == null)
            {
                return null;
            }
            return mgr;
        }
    }

    private void Awake()
    {
        damagedData = Resources.Load<Data>("Data/Data");
        if (mgr == null)
        {
            Debug.Log(mgr);
            
        }
        else { Destroy(this.gameObject); }

    }
    // Start is called before the first frame update
    public void OnExit()
    {       
        Instantiate(Resources.Load("ExitUI"));
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void OnDestroy()
    {
        Destroy(this.gameObject);
    }
    public void OnLobby()

    {
        Instantiate(Resources.Load("HomeUI"));
    }
    public void Lobby()
    {
        SceneData.S_instance.Lobby();
        SceneData.S_instance.TimeScaleon();
    }
    public void RePlay()
    {
       if(damagedData.maxHP <= 0) { damagedData.maxHP = 4; Debug.Log(damagedData.maxHP); }
       
        SceneData.S_instance.startGame(SceneData.S_instance.SceneName);
    }

   
}
