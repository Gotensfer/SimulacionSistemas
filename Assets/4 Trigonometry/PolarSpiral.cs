using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarSpiral : MonoBehaviour
{
    [SerializeField] Transform targetObjectForAnimation;

    [Header("Vectors")]
    [SerializeField] CustomVector2 polarCoordinate;
    [SerializeField] CustomVector2 cartesianCoordinate;

    [Header("Movement values")]
    [SerializeField] float degAnglePerSecond;
    [SerializeField] float degAngleAcceleration;
    float radAnglePerSecond;
    float radAngleAcceleration;

    [SerializeField] float radiusPerSecond;
    [SerializeField] float radiusAcceleration;

    [Header("Spiral bounds")]
    [SerializeField] float xTreshhold;
    [SerializeField] float yTreshhold;


    private void Start()
    {
        radAnglePerSecond = Mathf.Deg2Rad * degAnglePerSecond;
        radAngleAcceleration = Mathf.Deg2Rad * degAngleAcceleration;
    }

    float graceTime = 1;
    float remainingGraceTime;
    bool recentlyChangedDirection;

    private void Update()
    {
        if (recentlyChangedDirection)
        {
            remainingGraceTime -= Time.deltaTime;
            if (remainingGraceTime < 0)
            {
                recentlyChangedDirection = false;
                remainingGraceTime = graceTime;
            }
        }

        if ((Mathf.Abs(targetObjectForAnimation.position.x) > xTreshhold
            || Mathf.Abs(targetObjectForAnimation.position.y) > yTreshhold) && !recentlyChangedDirection)
        {
            // radAngleAcceleration *= -1;
            // radAnglePerSecond *= -1;

            radiusAcceleration *= -1;
            radiusPerSecond *= -1;

            recentlyChangedDirection = true;
            remainingGraceTime = graceTime;
        }

        radAnglePerSecond += radAngleAcceleration * Time.deltaTime;
        polarCoordinate.y += radAnglePerSecond * Time.deltaTime;

        radiusPerSecond += radiusAcceleration * Time.deltaTime;
        polarCoordinate.x += radiusPerSecond * Time.deltaTime;

        cartesianCoordinate = polarCoordinate.FromPolarToCartesian();
        targetObjectForAnimation.position = cartesianCoordinate;
    }
}
