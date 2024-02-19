using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour
{

    [SerializeField] Vector3 movedirection;
    public float moveSpeed;
    
    void Update()
    {
        transform.position += movedirection * moveSpeed * Time.deltaTime;
    }

    public void MoveTo(Vector3 direction)
    {
        movedirection = direction;
    }
}
