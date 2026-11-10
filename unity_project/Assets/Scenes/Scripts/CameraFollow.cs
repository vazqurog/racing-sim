using UnityEngine;

public class CameraFollow: MonoBehaviour
{   

    // tweak this in the editor
    public float moveSmoothness;
    public float rotSmoothness;

    public Vector3 moveOffset;
    public Vector3 rotOffset;

    public Transform carTarget;

    // FixedUpdate runs every 0.02 seconds and scans for physic changes. 
    void FixedUpdate()
    {
        FollowCar();
    }


    // FollowCar() calls on HandleMovement() & MovementRoation() to update the cameras position & rotation
    void FollowCar()
    {
        HandleMovement();
        HandleRotation();
    }

    // HandleMovement() Updates the cameras position as the car moves
    void HandleMovement()
    {
        Vector3 targetPos = new Vector3();

        // make sure that the car model is set ot the Car Target option in the unity editor
        targetPos = carTarget.TransformPoint(moveOffset);

        transform.position = Vector3.Lerp(transform.position, targetPos, moveSmoothness * Time.deltaTime);
    }

    // HandleRotation() updates the cameras rotaiton based of the position of the car
    // Quaternion are used here to capture all the available axis that we want to modify
    void HandleRotation()
    {
        var direction = carTarget.position - transform.position;
        var rotation = new Quaternion();

        rotation = Quaternion.LookRotation(direction + rotOffset, Vector3.up);

        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotSmoothness * Time.deltaTime);


    }

}
