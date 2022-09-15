using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class LookAtMoveDirection : MonoBehaviour
{
    Movement movement;
    CustomVector2 m_Direction;
    float radians;

    void Start()
    {
        movement = GetComponent<Movement>();   
    }

    void Update()
    {
        m_Direction = movement.velocity;
        radians = Mathf.Atan2(m_Direction.y, m_Direction.x);
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }
}
