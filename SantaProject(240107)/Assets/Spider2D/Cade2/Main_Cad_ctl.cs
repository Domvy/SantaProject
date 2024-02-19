using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Main_Cad_ctl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string folderName;
    public List<GameObject> iCube = new List<GameObject>();
    public List<Material> materialsList = new List<Material>();
    public List<Material> iCubeMaterials = new List<Material>();

    public List<Material> copyiCubeM = new List<Material>();
    public Material defaultmaterial;
    int materialcount;
    private GameObject premierObj;
    private GameObject douxiemeObj;
    bool click = false;
    bool endGame = false;
    public float cooltime = 60.0f;
    public float reCooltime = 0;
    public int correctCubeNum;
    public Button button;

    private int iCnt = 0;
    public Uiscript uiscript;
    public GameObject echecPan;

    void Start()
    {
        Time.timeScale = 1;
        if (!click)
        {
            for (int i = 0; i < iCube.Count; i++)
            {
                iCube[i].GetComponent<Cubeprivate>().setint(i);
                Debug.Log(iCube[i].GetComponent<Cubeprivate>().getint());
            }

            iCubeMaterials = new List<Material>(16);
            RandomMaterial();

            for (int i = 0; i < iCube.Count; i++)
            {
                iCubeMaterials.Add(iCube[i].GetComponent<MeshRenderer>().material);
            }

            copyiCubeM = iCubeMaterials.ToList();

            Invoke("unlodeMaterial", 3f);

        }


    }

    void Update()
    {
#if UNITY_EDITOR



        if (!NiveauStatic.loadGame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            if (hit.collider != null)
            {
                if (Input.GetMouseButtonUp(0) && !click)
                {

                    iCnt++;

                    if (iCnt == 1)
                    {
                        Debug.Log("11111111");
                        premierObj = hit.transform.gameObject;
                        premierObj.GetComponent<Animation>().Play();
                        StartCoroutine(TurnCube1());


                    }
                    else if (iCnt == 2)
                    {
                        Debug.Log("2222222222");
                        douxiemeObj = hit.transform.gameObject;
                        douxiemeObj.GetComponent<Animation>().Play();
                        StartCoroutine(TurnCube2());

                    }
                }
            }
        }
#elif UNITY_ANDROID || UNITY_IOS
    
        if (!NiveauStatic.loadGame)
        {
            if(Input.touchCount==1)
            {
                if (Input.GetTouch(0).phase==TouchPhase.Began && !click)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                    RaycastHit hit;
                    Physics.Raycast(ray, out hit);
                    if (hit.collider != null)
                    {
                        iCnt++;
                    
                        if (iCnt == 1)
                        {
                            Debug.Log("11111111");
                            premierObj = hit.transform.gameObject;
                            premierObj.GetComponent<Animation>().Play();
                            StartCoroutine(TurnCube1());
                       

                        }
                        else if (iCnt == 2)
                        {
                            Debug.Log("2222222222");
                            douxiemeObj = hit.transform.gameObject;
                            douxiemeObj.GetComponent<Animation>().Play();
                            StartCoroutine(TurnCube2());
                       
                        }
                        
                    }
                }
            }
            
        }
#endif


    }
    IEnumerator TurnCube1()
    {
        yield return new WaitForSeconds(0.30f);
        premierObj.GetComponent<MeshRenderer>().material = copyiCubeM[premierObj.GetComponent<Cubeprivate>().getint()];
    }

    IEnumerator TurnCube2()
    {
        Debug.Log("A");
        yield return new WaitForSeconds(0.30f);
        douxiemeObj.GetComponent<MeshRenderer>().material = copyiCubeM[douxiemeObj.GetComponent<Cubeprivate>().getint()];
        Debug.Log("B");
        Debug.Log("1111메터리얼 : " + premierObj.GetComponent<MeshRenderer>().material + " \n 2222메터리얼 : " + douxiemeObj.GetComponent<MeshRenderer>().material);
        if (premierObj == douxiemeObj)
        {
            douxiemeObj.GetComponent<MeshRenderer>().material = defaultmaterial;
            iCnt = 0;
        }
        else if (premierObj.GetComponent<MeshRenderer>().material.name == douxiemeObj.GetComponent<MeshRenderer>().material.name)
        {

            uiscript.correctCubeNum += 2;
            Debug.Log(uiscript.correctCubeNum);
            Debug.Log("정답");
        }
        else
        {
            Debug.Log("틀림!!");
            StartCoroutine(DifferentObj());
        }
        iCnt = 0;
    }

    IEnumerator DifferentObj()
    {
        click = true;
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(DifferantCubeTurn());

    }
    IEnumerator DifferantCubeTurn()
    {
        premierObj.GetComponent<Animation>().Play();
        douxiemeObj.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(0.3f);
        premierObj.GetComponent<MeshRenderer>().material = defaultmaterial;
        douxiemeObj.GetComponent<MeshRenderer>().material = defaultmaterial;
        click = false;
    }


    public void RandomMaterial()
    {
        materialcount = materialsList.Count;
        for (int i = 0; i < materialcount; i++)
        {
            int rand = Random.Range(0, materialsList.Count);
            //print(materialsList[rand]);
            iCube[i].GetComponent<MeshRenderer>().material = materialsList[rand];
            materialsList.RemoveAt(rand);
        }

    }


    public void unlodeMaterial()
    {
        for (int i = 0; i < iCube.Count; i++)
        {
            iCube[i].GetComponent<MeshRenderer>().material = defaultmaterial;
        }
        reCooltime = cooltime;
        StartCoroutine(CooltimeBut(button));
    }

    public IEnumerator CooltimeBut(UnityEngine.UI.Button button)
    {

        while (reCooltime > 0)
        {
            reCooltime -= Time.deltaTime;
            button.GetComponent<UnityEngine.UI.Image>().fillAmount = (reCooltime / cooltime);
            yield return new WaitForFixedUpdate();
        }

        echecPan.SetActive(true);
        StopAllCoroutines();
        NiveauStatic.loadGame = true;
    }
    public void ContinuBut()
    {
        Debug.Log("OK");
        echecPan.SetActive(false);
        NiveauStatic.loadGame = false;
        reCooltime = cooltime;
        StartCoroutine(CooltimeBut(button));
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