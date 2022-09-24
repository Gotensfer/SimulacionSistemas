using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalMovementTowardsTarget : MonoBehaviour
{
    enum MovementType
    {
        Linear,
        Accelerated
    }

    CustomVector2 position;
    CustomVector2 aceleracion;
    [HideInInspector] public CustomVector2 velocity;
    [SerializeField] Transform Target;

    [SerializeField] MovementType movementType;

    private void Start()
    {
        position = transform.position;
    }

    void Update()
    {
        switch (movementType)
        {
            case MovementType.Linear:
                MoveLinear();
                break;
            case MovementType.Accelerated:
                MoveAcelerated();
                break;
        }
    }

    void MoveAcelerated()
    {
        velocity = velocity + aceleracion * Time.deltaTime;
        position = position + velocity * Time.deltaTime;
        transform.position = position;

        aceleracion = Target.position - transform.position;
    }

    void MoveLinear()
    {
        velocity = (Target.position - transform.position).normalized;
        position = position + velocity * Time.deltaTime;
        transform.position = position;
    }
}
