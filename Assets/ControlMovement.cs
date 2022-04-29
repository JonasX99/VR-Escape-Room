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
    public float addHeight = 0.2f;
    public float Speed;
    public float Gravity = -9.81f;
    float fallingSpeed;
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
        CapsuleFollowHeadset();
        Quaternion headYaw = Quaternion.Euler(0,Origin.Camera.transform.eulerAngles.y,0);
        Vector3 direction = headYaw * new Vector3(movementinputAxis.x,0,movementinputAxis.y);
        controller.Move(direction * Speed * Time.fixedDeltaTime);
        if(controller.isGrounded) fallingSpeed = 0;
        else fallingSpeed += Gravity * Time.fixedDeltaTime;
        controller.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);
    }
    void CapsuleFollowHeadset(){
        controller.height = Origin.CameraInOriginSpaceHeight + addHeight;
        Vector3 capsuleCenter = transform.InverseTransformPoint(Origin.Camera.gameObject.transform.position);
        controller.center = new Vector3(capsuleCenter.x, controller.height/2 + controller.skinWidth, capsuleCenter.z);
    }
}
