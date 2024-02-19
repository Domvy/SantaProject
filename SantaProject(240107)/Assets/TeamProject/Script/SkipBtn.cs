using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;


public class SkipBtn : MonoBehaviour
{
    public List<GameObject> textList;
    public int next;
    public string M_name;
    bool on;
    public void SkipOn(string M_name)
    {

        SceneData.S_instance.startGame(M_name);
    }

    public void NextText()
    {
        next++;
        for (int i = 0; i < textList.Count; i++)
        {
            if (next <textList.Count)
            {
                if (next == i)
                {
                    textList[i].SetActive(true);

                }

                else
                {
                    textList[i].SetActive(false);
                }
            }
            else
            {
                if (!on) { SkipOn(M_name); on = !on; }
               
            }
           
        }
    }
    

}
