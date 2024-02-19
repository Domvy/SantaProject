using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{
 private int niveau1But=1;
 private int niveau2But=2;
 

    public void Nivaeu1Butt()
    {
        NiveauStatic.niveau = niveau1But;
    }
    public void Nivaeu2Butt()
    {
        NiveauStatic.niveau = niveau2But;
    }

    public void StartBut()
    {
        switch(NiveauStatic.niveau)
        {
            case 1:
                 SceneManager.LoadScene("MainGame");
                break;
            case 2:
                SceneManager.LoadScene("Niveau2");
                break;

        }
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

