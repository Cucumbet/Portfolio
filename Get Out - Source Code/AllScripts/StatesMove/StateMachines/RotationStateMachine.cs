using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;


public class RotationStateMachine : StateMachine
{
    public RotationaState rotationaState { get; protected set; }
    public Camera mainPlayerCamera;
    public float sensetive = 1;
    private float rotationX = 0;
    public float lookXLimit = 45f;
    public float lookSpeed = 2f;
    // Start is called before the first frame update
    float X = 0;
    float Y = 0;


    private void Awake()
    {

        rotationaState = new RotationaState(this);
    }
    protected override BaseState GetInitialState()
    {
        return rotationaState;


    }

    public void Rotate()
    {
        X += Input.GetAxis("Mouse X");
        Y -= Input.GetAxis("Mouse Y");


        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed * sensetive * 6;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        mainPlayerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed * sensetive * 6, 0);

    }
    // Update is called once per frame
}