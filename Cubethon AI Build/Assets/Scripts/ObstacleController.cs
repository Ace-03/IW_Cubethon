using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public Transform Player;
    public Vector3 Offset;

    public float maxSpeed;
    public Transform target;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        SteeringControl steering = GetSteering();
        transform.position += steering.linVelocity * Time.deltaTime;
    }

    SteeringControl GetSteering()
    { 
        SteeringControl result = new SteeringControl();

        result.linVelocity = -target.position + this.transform.position;

        result.linVelocity = result.linVelocity.normalized * maxSpeed;

        float angle = NewOrientation(transform.eulerAngles.y, result.linVelocity);
        angle *= Mathf.Rad2Deg;
        this.transform.eulerAngles = new Vector3(0, angle, 0);

        result.angVelocity = 0;
        return result;
    }

    float NewOrientation(float currentOrientaion, Vector3 velocity)
    {
        if (velocity.magnitude > 0)
            return Mathf.Atan2(-velocity.x, -velocity.z);
        else
            return currentOrientaion;
    }
}
