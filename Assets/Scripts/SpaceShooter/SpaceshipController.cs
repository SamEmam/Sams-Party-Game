using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class SpaceshipController : MonoBehaviour
{
    public float verticalInputAcceleration = 1;
    public float horizontalInputAcceleration = 20;
    public XboxController controller;

    public float maxSpeed = 10;
    public float maxRotationSpeed = 100;

    public float velocityDrag = 1;
    public float rotationDrag = 1;

    private Vector3 velocity;
    private float zRotationVelocity;

    private void Update()
    {
        // apply forward input
        Vector3 acceleration = XCI.GetAxis(XboxAxis.RightTrigger, controller) * verticalInputAcceleration * transform.forward;
        velocity += acceleration * Time.deltaTime;

        // apply turn input
        float zTurnAcceleration = -1 * XCI.GetAxis(XboxAxis.LeftStickX, controller) * horizontalInputAcceleration;
        zRotationVelocity += zTurnAcceleration * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        // apply velocity drag
        velocity = velocity * (1 - Time.deltaTime * velocityDrag);

        // clamp to maxSpeed
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        // apply rotation drag
        zRotationVelocity = zRotationVelocity * (1 - Time.deltaTime * rotationDrag);

        // clamp to maxRotationSpeed
        zRotationVelocity = Mathf.Clamp(zRotationVelocity, -maxRotationSpeed, maxRotationSpeed);

        // update transform
        transform.position += velocity * Time.deltaTime;
        transform.Rotate(0, -zRotationVelocity * Time.deltaTime, 0);
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        //transform.rotation = Quaternion.Euler(0, transform.rotation.y, 0);
    }
}