using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionInfo : MonoBehaviour
{

    [SerializeField] GameObject[] MissionUi;
    Button Bnext;


    private void Awake()
    {
        Bnext = transform.Find("next").GetComponent<Button>();
        Bnext.onClick.AddListener(NextBut);
    }
    private void OnEnable()
    {
        string M_name = SceneData.S_instance.SceneName;
        for (int i = 0; i < MissionUi.Length; i++)
        {
            if (M_name == MissionUi[i].name)
            {
                MissionUi[i].SetActive(true);
            }
            else { MissionUi[i].SetActive(false); }

        }
    }

    void NextBut()
    {
        StartCoroutine(WaiteNextScene());   
    }
    IEnumerator WaiteNextScene()
    {
        yield return new WaitForEndOfFrame();
        Debug.Log("ok");
        SceneData.S_instance.G_mission_ui(SceneData.S_instance.SceneName);

    }
}
