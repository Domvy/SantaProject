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
        [Tooltip("전체 시간 타이머")]
        public float defaultTimer;
        [Tooltip("데미지를 입었을 때 발동되는 타이머")]
        public float damagedTimer;        
        
        [Header("Damage Data")]        
        [Tooltip("넉백 당하는 힘")]
        [Range(0, 1000)]
        public float knockBack;
        [Tooltip("넉백 시 움직이지 못하는 시간")]
        [Range(0,10)]
        public float knockBackTime;
        [Tooltip("넉백 후 무적시간")]
        [Range(0,10)]
        public float damagedTime;        
        
        [Header("Player Data")]
        [Tooltip("플레이어 이름")]
        public string playerName;
        [Tooltip("플레이어 체력")]
        public int maxHP;
        [Tooltip("플레이어 이동 속도")]
        [Range(0,100)]
        public float moveSpeed;
        [Tooltip("플레이어 점프 수치")]
        [Range(0,100)]
        public float jumpPower;
        [Tooltip("플레이어 점프 횟수")]
        public int jumpCount;
        [Header("소지한 아이템")]
        [Tooltip("아이템 종류")]
        [SerializeField]
        private List<string> itemType = new List<string>();
        [Tooltip("플레이어가 가지고 있는 아이템 목록")]
        [SerializeField]
        private List<int> itemList = new List<int>();
    }    
}





