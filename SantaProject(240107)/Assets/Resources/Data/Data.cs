using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UserDatabase;
using UnityEditor;



namespace UserDatabase
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject / Data", order = int.MaxValue)]
    public class Data : ScriptableObject
    {
        [Header("Time Data")]
        [Tooltip("��ü �ð� Ÿ�̸�")]
        public float defaultTimer;
        [Tooltip("�������� �Ծ��� �� �ߵ��Ǵ� Ÿ�̸�")]
        public float damagedTimer;        
        
        [Header("Damage Data")]        
        [Tooltip("�˹� ���ϴ� ��")]
        [Range(0, 1000)]
        public float knockBack;
        [Tooltip("�˹� �� �������� ���ϴ� �ð�")]
        [Range(0,10)]
        public float knockBackTime;
        [Tooltip("�˹� �� �����ð�")]
        [Range(0,10)]
        public float damagedTime;        
        
        [Header("Player Data")]
        [Tooltip("�÷��̾� �̸�")]
        public string playerName;
        [Tooltip("�÷��̾� ü��")]
        public int maxHP;
        [Tooltip("�÷��̾� �̵� �ӵ�")]
        [Range(0,100)]
        public float moveSpeed;
        [Tooltip("�÷��̾� ���� ��ġ")]
        [Range(0,100)]
        public float jumpPower;
        [Tooltip("�÷��̾� ���� Ƚ��")]
        public int jumpCount;
        [Header("������ ������")]
        [Tooltip("������ ����")]
        [SerializeField]
        private List<string> itemType = new List<string>();
        [Tooltip("�÷��̾ ������ �ִ� ������ ���")]
        [SerializeField]
        private List<int> itemList = new List<int>();
    }    
}





