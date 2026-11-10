using System;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public enum Axel
    {
        Front,
        Rear
    }
    // Serlalizable allows the following variables to become accessible for editing and viewing in the unity editor. 
    [Serializable]
    public struct Wheel
    {
        public GameObject wheelModel;
        public WheelCollider wheelCollider;
        public Axel axel;
    }

    public float maxAcceleration = 30.0f;
    public float brakeAcceleration = 50.0f;

    public float turnSensitivity = 1.0f;
    public float maxSteerAngle = 30.0f;

    public Vector3 _centerOfMass; //new Vector3(0.0f,-.25f,0.0f);

    public List<Wheel> wheels;

    float moveInput; 
    float steerInput;

    private Rigidbody carRb;


    void Start()
    {
        carRb = GetComponent<Rigidbody>();

        // Y is set to -.25 in the unity editor to avoid the car from flipping. 
        // setting the class member didn't update the Car body
        carRb.centerOfMass = _centerOfMass;
    }
    
    // The Update() function run once per frame and captures input and animations
    void Update()
    {
        GetInputs();
        AnimateWheels();
    }

    // The FixedUpdate() function is where most physic related things go since this function runs every 0.02 seconds. 
    void FixedUpdate()
    {
        Move();
        Steer();
        Brake();
    }

    // Scans for inputs 
    // vertical = W, S
    // horizontal = A, D 
    void GetInputs()
    {
        moveInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");
    }

    // Update the torque of each wheel 
    void Move()
    {
        foreach (var wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = moveInput * maxAcceleration * 300 * Time.deltaTime;
        }
    }

    // Steer() handles the logic for turning the vehicle, this updates the steeting angle in the wheelCollider 
    void Steer()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                var _steerAngle = steerInput * turnSensitivity * maxSteerAngle;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _steerAngle, 0.6f);
            }
        }
    }

    // FIXME: update the controls.md docs to match the expected controls
    // Brake() scans for the " brake " input the slows the vehicle down
    void Brake()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            foreach(var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 300 * brakeAcceleration * Time.deltaTime;
            }
        }
        else
        {
            foreach(var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 0;
            }
        }
    }

    // AnimateWheels() updates the roation and position of each wheel to handle animations.
    // this handles both moving roations and turning position
    void AnimateWheels()
    {
        foreach(var wheel in wheels)
        {
            Quaternion rot;
            Quaternion rotationOffset = new Quaternion(0f,90f,0f,0f);
            Vector3 pos;
            wheel.wheelCollider.GetWorldPose(out pos, out rot);
            wheel.wheelModel.transform.position = pos;
            // 90 makes the left side correct, -90 makes the right side correct
            // fix model in blender ?
            wheel.wheelModel.transform.rotation = rot * Quaternion.Euler(0f, -90f, 0f);

        }
    }
}
