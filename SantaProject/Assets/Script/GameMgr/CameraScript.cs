using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform player;
    private Vector3 pos;
    [SerializeField]
    private float cameraSpeed;
    [SerializeField]
    private float xAngle;
    [SerializeField]
    private float yAngle;
    private Vector3 finPos;
    private Vector3 defaultPos;
    [SerializeField]
    private bool imageFlip;
    private bool camereFlip = true;
    private bool isMoving;

    float height;
    float width;
    float clampX;
    float clampY;
    public int mapSizeXL; 
    public int mapSizeXR;
    public int mapSizeYD;
    public int mapSizeYH;    

    void Start()
    {
        pos = gameObject.transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
    }
    void Update()
    {
        isMoving = player.GetComponent<PlayerCtrl>().isMove;
        imageFlip = player.GetComponentInChildren<SpriteRenderer>().flipX;
        if (imageFlip != camereFlip) { xAngle = -xAngle; camereFlip = imageFlip; }
        finPos = new Vector3(player.transform.position.x + xAngle, player.transform.position.y + yAngle);        
        defaultPos = new Vector3(player.transform.position.x, player.transform.position.y + yAngle);
        if (isMoving) { transform.position = Vector3.Lerp(transform.position, pos + finPos, Time.deltaTime * cameraSpeed); }
        if (!isMoving) { transform.position = Vector3.Lerp(transform.position, pos + defaultPos, Time.deltaTime * cameraSpeed); }
        LimitArea();
    }
    void LimitArea()
    {
        float lx = mapSizeXL - width;
        float rx = mapSizeXR - width;        
        float ly = mapSizeYD - height;
        float ry = mapSizeYH - height;
        clampX = Mathf.Clamp(transform.position.x, -lx, rx);
        clampY = Mathf.Clamp(transform.position.y, -ly, ry);
        transform.position = new Vector3(clampX, clampY, -10f);
    }
}
