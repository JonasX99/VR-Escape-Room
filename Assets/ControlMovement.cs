using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Unity.XR.CoreUtils;

public class ControlMovement : MonoBehaviour
{
    CharacterController controller;
    XROrigin Origin;
    Vector2 movementinputAxis;
    public XRNode movementinputSource;
    public float Speed;
    public float Gravity = -9.81f;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Origin = GetComponent<XROrigin>();
    }
    void Update()
    {
        InputDevice movementdevice = InputDevices.GetDeviceAtXRNode(movementinputSource);
        movementdevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out movementinputAxis);
    }
    void FixedUpdate(){
        Quaternion headYaw = Quaternion.Euler(0,Origin.Camera.transform.eulerAngles.y,0);
        Vector3 direction = headYaw * new Vector3(movementinputAxis.x,0,movementinputAxis.y);
        controller.Move(direction * Speed * Time.fixedDeltaTime);
    }
}
