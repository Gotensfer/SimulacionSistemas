using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassMovement : MonoBehaviour
{
    [SerializeField] CustomVector2 force;
    [SerializeField] CustomVector2 wind;
    [SerializeField] CustomVector2 position;
    [SerializeField] CustomVector2 aceleracion;
    [SerializeField] CustomVector2 velocity;
    [Range(0, 1), SerializeField] float dampingFactor;
    [SerializeField] float mass = 1f;

    void Start()
    {
        position = transform.position;
    }

    private void Update()
    {
        aceleracion.Draw(position, Color.blue);
        position.Draw(Color.green);
        velocity.Draw(position, Color.red);
    }

    private void FixedUpdate()
    {
        aceleracion *= 0;
        ApplyForce(force);
        ApplyForce(wind);
       
        
        if (position.x < -5 || position.x > 5)
        {
            position.x = Mathf.Sign(position.x) * 5;
            velocity.x *= -1;
            velocity *= dampingFactor;
        }
        if (position.y < -5 || position.y > 5)
        {
            position.y = Mathf.Sign(position.y) * 5;
            velocity.y *= -1;
            velocity *= dampingFactor;
        }
    }
    public void Move()
    {
        velocity = velocity + aceleracion * Time.fixedDeltaTime;
        position = position + velocity * Time.fixedDeltaTime;
        transform.position = position;
    }

    void ApplyForce(CustomVector2 force)
    {
        aceleracion += force * (1/mass);
        Move();
    }
}
