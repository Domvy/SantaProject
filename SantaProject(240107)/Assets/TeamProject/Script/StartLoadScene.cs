using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLoadScene : MonoBehaviour
{
    [SerializeField]
    List<AsyncOperation> sceneToload = new List<AsyncOperation>();

    public void startGame(string scenename)
    {
        sceneToload.Add(SceneManager.LoadSceneAsync("BaseScene"));
        sceneToload.Add(SceneManager.LoadSceneAsync(scenename, LoadSceneMode.Additive));
    }
  
}
