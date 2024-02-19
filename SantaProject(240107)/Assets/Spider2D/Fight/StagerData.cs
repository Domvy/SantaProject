using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StagerData : ScriptableObject
{
    [SerializeField]
    private Vector2 limitMin, limitMax;

    public Vector2 LimitMin => limitMin;
    public Vector2 LimitMax => limitMax;


}
