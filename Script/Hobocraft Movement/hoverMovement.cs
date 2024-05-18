using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoverMovement : MonoBehaviour
{
    public float accelerator = 500f;
    public float breakingForce = 300f;
    public float maxTurnAngle = 25f;

    private float currentAccelerator = 0f;
    private float currentbreakingForce = 0f;
    private float currentTurnAngle = 0f;

    public WheelCollider frontRight;
    public WheelCollider frontLeft;
    public WheelCollider backRight;
    public WheelCollider backLeft;

    public Transform frontRightTransform;
    public Transform frontLeftTransform;
    public Transform backRightTransform;
    public Transform backLeftTransform;

    public GameOver GameOverr;


    public void GameOver()
    {
        GameOverr.Setup();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        currentAccelerator = accelerator * Input.GetAxis("Vertical");


        if (Input.GetKey(KeyCode.Space))
        {
            currentbreakingForce = breakingForce;
        } else
        {
            currentbreakingForce = 0;
        }

        frontRight.motorTorque = currentAccelerator;
        frontLeft.motorTorque = currentAccelerator;
        
        frontRight.brakeTorque = currentbreakingForce;
        frontLeft.brakeTorque = currentbreakingForce;
        backRight.brakeTorque = currentbreakingForce;
        backLeft.brakeTorque = currentbreakingForce;

        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;

        UpdateWheel(frontRight, frontRightTransform);
        UpdateWheel(frontLeft, frontLeftTransform);
        UpdateWheel(backRight, backRightTransform);
        UpdateWheel(backLeft, backLeftTransform);
    }

    void UpdateWheel(WheelCollider col, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        trans.position = position;
        trans.rotation = rotation;
    }
}
