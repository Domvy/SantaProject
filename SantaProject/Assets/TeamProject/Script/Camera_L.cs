using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Camera_L : MonoBehaviour
{

    [SerializeField] Camera _camera;
    private static Camera_L instance;
    public static Camera_L Instance
    {
        get
        {
            if (instance == null)
            { return null; }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null) { instance = this; DontDestroyOnLoad(this.gameObject); }
        else { Destroy(this.gameObject); }


    }

    private void Update()
    {
        if (_camera != null) { return; }
        else
        {
            //_camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
            //Debug.Log(_camera);
            Rect rect = _camera.rect;
            float scaleheight = ((float)Screen.width / Screen.height) / ((float)16 / 9);//(가로/세로)
            float scalewidth = 1f / scaleheight;
            if (scaleheight < 1)
            {
                rect.height = scaleheight;
                rect.y = (1f - scaleheight) / 2f;
            }
            else
            {
                rect.width = scalewidth;
                rect.x = (1f - scalewidth) / 2f;
            }
            _camera.rect = rect;
        }



    }

}
