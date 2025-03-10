using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private Vector3 movedirestion;
    private float movespeed = 4f;
    public Rigidbody boby;
    float jumpP = 5f;

    // Update is called once per frame
    void Update()
    {
        bool hascontrol = (movedirestion != Vector3.zero);
        if(hascontrol)
        {
            transform.rotation = Quaternion.LookRotation(movedirestion);
            transform.Translate(Vector3.forward * movespeed * Time.deltaTime);
        }
    }
    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        if(input!=null)
        {
            movedirestion = new Vector3(input.x, 0f, input.y);

        }
    }

    private void OnJump()
    {
        boby.AddForce(Vector3.up * jumpP, ForceMode.Impulse);
    }
}
