using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Uiscript : MonoBehaviour
{
    public Text correctCube;
    public Maincontrole maincontrole;
    public int correctCubeNum=0;
    public GameObject felicitation;
   

    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        correctCube.text = "찾은 색의 수 : " + correctCubeNum;
        if(correctCubeNum==maincontrole.iCube.Count)
        {
            felicitation.SetActive(true);
            StopAllCoroutines();
            //NiveauStatic.loadGame = true;
        }
    }

    public void NiveauUpBut()
    {
        SceneManager.LoadScene("Niveau2");
        //NiveauStatic.loadGame = false;
    }
    public void EndBut()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_ANDROID || UNITY_IOS
        Application.Quit();        
#endif
    }
}
