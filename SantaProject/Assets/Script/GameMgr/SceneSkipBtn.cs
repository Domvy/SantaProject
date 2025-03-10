using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSkipBtn : MonoBehaviour
{
    int btnN;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += LoadSceneEvent;
    }
    private void LoadSceneEvent(Scene scene, LoadSceneMode mode)     
    {
        gameObject.transform.GetChild(0).gameObject.GetComponent<Canvas>().worldCamera = Camera.main;
    }
    public void DevSceneMove(string sceneName)
    {
        SceneData.S_instance.startGame(sceneName);
    }
    public void ClearScene()
    {
        SceneData.S_instance.MissionCrear("crear");
    }
}
