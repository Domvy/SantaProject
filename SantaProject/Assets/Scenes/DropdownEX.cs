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
        dropdown.ClearOptions();    //�ɼ��� ����
        List<TMP_Dropdown.OptionData>options=new List<TMP_Dropdown.OptionData>();
        foreach(string str in arrayclass)// ���ڿ��� �ɼ� ����Ʈ�� �־���
        {
            options.Add(new TMP_Dropdown.OptionData(str));  
        }

        dropdown.AddOptions(options);// �ɼǸ���Ʈ�� �ɼ� ���� �߰�
        dropdown.value = 0;// ���õ� �ɼ��� 0���� ����
    }

}
