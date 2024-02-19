using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemyDatabase;

namespace EnemyDatabase
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObject / EnemyData", order = int.MaxValue)]
    public class EnemyData : ScriptableObject
    {
        [Header("참새")]
        [Tooltip("이동속도")]
        [Range(1,10)]
        public float sparrowMoveSpeed = 5;
        [Header("개")]
        [Tooltip("이동속도")]
        [Range(1,10)]
        public float dogMoveSpeed = 3;
        [Header("까마귀")]
        [Tooltip("이동속도")]
        [Range(1, 10)]
        public float crowMoveSpeed = 5;
    }
}

