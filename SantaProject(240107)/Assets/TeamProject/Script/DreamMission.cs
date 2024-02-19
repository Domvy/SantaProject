using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DreamMission : MonoBehaviour
{
   
    Button Bnext;


    private void Awake()
    {
        Bnext = transform.Find("next").GetComponent<Button>();
        Bnext.onClick.AddListener(NextBut);
    }
    

    void NextBut()
    {
        SceneData.S_instance.G_mission_ui(SceneData.S_instance.SceneName);

    }
}
