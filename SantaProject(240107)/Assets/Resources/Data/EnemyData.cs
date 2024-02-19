using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemyDatabase;

namespace EnemyDatabase
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObject / EnemyData", order = int.MaxValue)]
    public class EnemyData : ScriptableObject
    {
        [Header("����")]
        [Tooltip("�̵��ӵ�")]
        [Range(1,10)]
        public float sparrowMoveSpeed = 5;
        [Header("��")]
        [Tooltip("�̵��ӵ�")]
        [Range(1,10)]
        public float dogMoveSpeed = 3;
        [Header("���")]
        [Tooltip("�̵��ӵ�")]
        [Range(1, 10)]
        public float crowMoveSpeed = 5;
    }
}

