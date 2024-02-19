using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathAcess : MonoBehaviour
{
    [SerializeField] private string folderName;     //사용할 폴더
    public Material[] cubeMaterials; // 저장할 메터리얼
    public GameObject cubeObj; // 큐브 오브젝트

    // Start is called before the first frame update
    void Start()
    {
        // 무조건 이 스크립트가 들어가면 경로 //* Assets/Resource/(folderName)/ 에 있어야한다.
        Material[] objs = Resources.LoadAll<Material>(folderName); // 폴더안에 Material로 구성된 것들을 전부 불러온다.
        //Object[] objs = Resources.LoadAll(folderName);  //폴더 검색
        cubeMaterials = new Material[objs.Length]; // 폴더에서 찾아낸 크기만큼 cubeMaterials의 사이즈를 할당!!
        for (int i = 0; i < objs.Length; i++)
        {
            Debug.Log(objs[i].name);
            cubeMaterials[i] = objs[i]; //경로에서 저장한 Materials들을 이 스크립트의
            // cubeMaterials[i]에 저장  
        }
        cubeObj.GetComponent<MeshRenderer>().material = cubeMaterials[0]; // 저장한 것 이 
    }
}
