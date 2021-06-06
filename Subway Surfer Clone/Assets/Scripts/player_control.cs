using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour
{
    //character controller
    private CharacterController controller = null;
    private float jumpForce = 4.0f;
    private float gravity = 12.0f;
    private float verticalVelocity;
    public float speed = 7.0f;
    public float lateralSpeed = 14f;

    public KeyCode leftKey;
    public KeyCode rightKey;
    public float laneDistance = 5f;
    public int desiredLane = 1; 
    // 0: Left, 1: Middle, 2: Right

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Gather Input for lane determination
        if(Input.GetKeyDown(leftKey))
            moveLane(false);
        if(Input.GetKeyDown(rightKey))
            moveLane(true);

        // Where we should be in future
        Vector3 targetPosition = transform.position.z * Vector3.forward;
        if(desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if(desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        //move vector x for player controller
        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetPosition - transform.position).normalized.x *lateralSpeed;

        //move vector y for jump
        moveVector.y = -0.1f;
        
        // move vector z for moving forward
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);

    }

    void moveLane(bool movingRight)
    {
        //moving right
        if(movingRight)
        {
            desiredLane += (movingRight) ? 1 : -1;
            desiredLane = Mathf.Clamp(desiredLane, 0, 2);

        }
        //moving left
        if(!movingRight)
        {
            desiredLane += (!movingRight) ? -1 : 1;
            desiredLane = Mathf.Clamp(desiredLane, 0, 2);

        }
    }

}
