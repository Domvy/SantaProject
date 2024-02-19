using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropdownEX : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    private string[] arrayclass = new string[5] { "c1", "c2", "c3", "c4", "c5" };
    // Start is called before the first frame update
    void Start()
    {
        dropdown.ClearOptions();    //옵션을 지움
        List<TMP_Dropdown.OptionData>options=new List<TMP_Dropdown.OptionData>();
        foreach(string str in arrayclass)// 문자열을 옵션 리스트에 넣어줌
        {
            options.Add(new TMP_Dropdown.OptionData(str));  
        }

        dropdown.AddOptions(options);// 옵션리스트를 옵션 값에 추가
        dropdown.value = 0;// 선택된 옵션을 0으로 설정
    }

}
