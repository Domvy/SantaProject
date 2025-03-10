using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.SceneManagement;


public class SceneData : ScriptableObject
{
    private const string settingFileDirectory = "Assets/Resources";
    private const string settingFilePath = "Assets/Resources/SceneData.asset";

    private static SceneData s_instance;
    public static SceneData S_instance
    {
        get
        {
            if (s_instance != null)
            {
                return s_instance;
            }
            s_instance = Resources.Load<SceneData>("SceneData");
#if UNITY_EDITOR
            if (s_instance == null)
            {
                if (!AssetDatabase.IsValidFolder(settingFileDirectory))
                {
                    AssetDatabase.CreateFolder("Assets", "Resources");
                }
                s_instance = AssetDatabase.LoadAssetAtPath<SceneData>(settingFilePath);

                if (s_instance == null)
                {
                    s_instance = CreateInstance<SceneData>();
                    AssetDatabase.CreateAsset(s_instance, settingFilePath);
                }
            }
#endif
            return s_instance;
        }
    }


    [SerializeField]
    List<AsyncOperation> sceneToload = new List<AsyncOperation>();
    [SerializeField]
    public string missionCrear, REname, SceneName;
    [SerializeField]
    public string Failed;



    public void startGame(string M_scenename)
    {
        if (Time.timeScale == 0) { TimeScaleon(); }
        sceneToload.Add(SceneManager.LoadSceneAsync(M_scenename));
        sceneToload.Add(SceneManager.LoadSceneAsync("BaseScene", LoadSceneMode.Additive));
    }

    //IEnumerator startGame(string M_scenename)
    //{
    //    yield return new WaitForEndOfFrame();
    //    if (Time.timeScale == 0) { TimeScaleon(); }
    //    sceneToload.Add(SceneManager.LoadSceneAsync(M_scenename));
    //    sceneToload.Add(SceneManager.LoadSceneAsync("BaseScene", LoadSceneMode.Additive));
    //}


    public void Lobby()
    {
        TimeScaleon();
        //SceneManager.LoadScene("Lobby");
        SceneManager.LoadScene(0);                
    }          
    public void FailedUi(string failed)
    {
        if (failed == "failed")
        {
            Instantiate(Resources.Load("FailedUI"));
            Debug.Log("uion");
            SceneData.S_instance.Failed = "";
        }
        TimeScaleoff();
    }

    public void MissionCrear(string crear)
    {

        if (crear == "crear")
        {

            Instantiate(Resources.Load("CrearUI"));

            SceneData.S_instance.missionCrear = "";
        }
        TimeScaleoff();

    }
    public void G_mission_ui(string SName)
    {

        switch (SName)
        {
            case "level01_1":
                startGame("level01_2");
                TimeScaleon();
                break;
            case "level01_2":

                startGame("level01_3");
                TimeScaleon();
                break;
            case "level01_3":

                startGame("level02_1");
                TimeScaleon();
                break;

            case "level02_1":
                startGame("level02_2");
                TimeScaleon();
                break;

            case "level02_2":

                startGame("level02_3");
                TimeScaleon();
                break;

            case "level02_3":

                startGame("level03_1");
                TimeScaleon();
                break;

            case "level03_1":

                startGame("level03_2");
                TimeScaleon();
                break;

            case "level03_2":
                startGame("level03_3");
                TimeScaleon();
                break;

            case "level03_3":
                SceneManager.LoadScene("Ending");

                TimeScaleon();
                break;
        }

    }
    public void TimeScaleon()
    {
        Time.timeScale = 1;
    }

    public void TimeScaleoff()
    {
        Time.timeScale = 0;
    }

}
