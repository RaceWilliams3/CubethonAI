using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicSeek
{ 
    public Transform character;
    public Transform target;

    public float maxSpeed;

    public KinematicSteeringOutput getSteering(bool willFlee)
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();

        result.velocity = target.position - character.position;

        result.velocity.Normalize();
        result.velocity *= maxSpeed;
        if (willFlee)
            result.velocity *= -1;

        float targetAngle = newOrientation(character.rotation.eulerAngles.y, result.velocity);
        character.eulerAngles = new Vector3(0, targetAngle, 0);

        result.rotation = 0;
        return result;
    }

    public float newOrientation(float current, Vector3 velocity)
    {
        if (velocity.magnitude > 0)
        {
            float targetAngle = Mathf.Atan2(velocity.x, velocity.z);

            targetAngle *= Mathf.Rad2Deg;
            return targetAngle;
        }
        else
        {
            return current;
        }
    }

    void Update()
    {
        //getSteering();
    }
}
