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
        Debug.Log("해상도가 변경되었습니다.");
        Debug.Log(SceneManager.GetActiveScene().name);
    }
    //private void CameraRectCtrl() //카메라 범위 변경
    //{
    //    if (camera == null) { camera = Camera.main; }

    //    Rect rect = camera.rect;
    //    float scaleheight = ((float)Screen.width / Screen.height) / ((float)16f / 9f); // (가로 / 세로)
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

        int setWidth = 1920; // 사용자 설정 너비
        int setHeight = 1080; // 사용자 설정 높이

        int deviceWidth = Screen.width; // 기기 너비 저장
        int deviceHeight = Screen.height; // 기기 높이 저장

        Screen.SetResolution(setWidth, (int)(((float)deviceHeight / deviceWidth) * setWidth), true); // SetResolution 함수 제대로 사용하기

        if ((float)setWidth / setHeight < (float)deviceWidth / deviceHeight) // 기기의 해상도 비가 더 큰 경우
        {
            float newWidth = ((float)setWidth / setHeight) / ((float)deviceWidth / deviceHeight); // 새로운 너비
            camera.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // 새로운 Rect 적용
        }
        else // 게임의 해상도 비가 더 큰 경우
        {
            float newHeight = ((float)deviceWidth / deviceHeight) / ((float)setWidth / setHeight); // 새로운 높이
            camera.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // 새로운 Rect 적용
        }
    }
}
