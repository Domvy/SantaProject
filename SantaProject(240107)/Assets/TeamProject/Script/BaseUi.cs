using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UserDatabase;
using TMPro;

public class BaseUi : MonoBehaviour
{
    public Data playerData;
    string S_name;
    string[] Nameline;
    string FiarstName;
    [SerializeField] GameObject heart;
    [SerializeField] Image[] PosH;
    [SerializeField] TMP_Text stage;
    [SerializeField] Sprite full_H,end_H;

    int Hp;
    // Start is called before the first frame update

   

    private void Start()
    {
        S_name = SceneData.S_instance.SceneName;
        Nameline = S_name.Split('_');
        
        playerData = Resources.Load<Data>("Data/Data");
    }
    // Update is called once per frame
    void Update()
    {
        LevelText();
        stage.text = FiarstName;

        if (Nameline[1]=="1")
        {
            heart.SetActive(true);
            Hp = playerData.maxHP;
            foreach (Image img in PosH)
            {
                img.sprite = end_H;
            }
            for (int i = 0; i < Hp; i++)
            {

                PosH[i].sprite = full_H;
            }
        }
        else { heart.SetActive(false); }
    }

    void LevelText()
    {
        string F_name = Nameline[0];
        switch(F_name)
        {
            case "level01":
                FiarstName = "Stage1";
                break;

            case "level02":
                FiarstName = "Stage2";
                break;

            case "level03":
                FiarstName = "Stage3";
                break;

        }
    }
}
