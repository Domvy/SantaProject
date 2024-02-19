using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraRect : MonoBehaviour
{
    [SerializeField]
    private Camera camera;
    void Awake()
    {
        SceneManager.sceneLoaded += LoadedSceneEvent;
        SetResolution();
        //DebugLog();
    }
    private void LoadedSceneEvent(Scene scene, LoadSceneMode mode)
    {        
        SetResolution();
        //DebugLog();
    }
    private void DebugLog()
    {
        Debug.Log("�ػ󵵰� ����Ǿ����ϴ�.");
        Debug.Log(SceneManager.GetActiveScene().name);
    }
    //private void CameraRectCtrl() //ī�޶� ���� ����
    //{
    //    if (camera == null) { camera = Camera.main; }

    //    Rect rect = camera.rect;
    //    float scaleheight = ((float)Screen.width / Screen.height) / ((float)16f / 9f); // (���� / ����)
    //    float scalewidth = 1f / scaleheight;
    //    if (scaleheight < 1)
    //    {
    //        rect.height = scaleheight;
    //        rect.y = (1f - scaleheight) / 2f;
    //    }
    //    else
    //    {
    //        rect.width = scalewidth;
    //        rect.x = (1f - scalewidth) / 2f;
    //    }
    //    camera.rect = rect;
    //}
    private void SetResolution()
    {
        if (camera == null) { camera = Camera.main; }

        int setWidth = 1920; // ����� ���� �ʺ�
        int setHeight = 1080; // ����� ���� ����

        int deviceWidth = Screen.width; // ��� �ʺ� ����
        int deviceHeight = Screen.height; // ��� ���� ����

        Screen.SetResolution(setWidth, (int)(((float)deviceHeight / deviceWidth) * setWidth), true); // SetResolution �Լ� ����� ����ϱ�

        if ((float)setWidth / setHeight < (float)deviceWidth / deviceHeight) // ����� �ػ� �� �� ū ���
        {
            float newWidth = ((float)setWidth / setHeight) / ((float)deviceWidth / deviceHeight); // ���ο� �ʺ�
            camera.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // ���ο� Rect ����
        }
        else // ������ �ػ� �� �� ū ���
        {
            float newHeight = ((float)deviceWidth / deviceHeight) / ((float)setWidth / setHeight); // ���ο� ����
            camera.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // ���ο� Rect ����
        }
    }
}
