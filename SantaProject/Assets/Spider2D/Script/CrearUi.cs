using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CrearUi : MonoBehaviour
{
    Button Home, Bnext;
    [SerializeField] string last;
    [SerializeField] string mission, dream,next;
    
    private void Awake()
    {
        
        Home = transform.Find("home").GetComponent<Button>();
        Bnext= transform.Find("nextplay").GetComponent<Button>();

        Home.onClick.AddListener(SceneData.S_instance.Lobby);
        Bnext.onClick.AddListener(Choice_ui);
    }



    void Choice_ui()
    {
        string M_name = SceneData.S_instance.SceneName;
        string[] Rneme = M_name.Split('_');
        last = Rneme[1];    
        Debug.Log(last);    
        switch (last)
        {
            case "1":
                MissionUiOn();
                break;
            case "2":
                Dream_start();
                break;
            case "3":
                Next_start();
                break;
        }
    }

    void MissionUiOn()
    {
        Instantiate(Resources.Load("MissionInfoUI"));
    }

    void Dream_start()
    {
        Instantiate(Resources.Load("DreamStart"));
    }
    void Next_start()
    {
        Instantiate(Resources.Load("NextStep"));
    }
}
