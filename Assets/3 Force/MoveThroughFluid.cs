using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveThroughFluid : MonoBehaviour
{
    [SerializeField] CustomVector2 wind;
    [SerializeField] CustomVector2 position;
    [SerializeField] CustomVector2 aceleracion;
    [SerializeField] CustomVector2 velocity;
    [Range(0, 1), SerializeField] float dampingFactor;

    [Header("Water drag")]
    [SerializeField] float waterDragCoefficient;
    [SerializeField] float frontalArea;
    [SerializeField] float mass = 1f;
    [SerializeField] float gravity = 9.8f;
    [SerializeField] float weight;
    [SerializeField] CustomVector2 weightForce;
    [SerializeField] CustomVector2 force;
    [SerializeField] CustomVector2 dragForce;

    void Start()
    {
        position = transform.position;
    }

    private void Update()
    {
        aceleracion.Draw(position, Color.blue);
        position.Draw(Color.green);
        velocity.Draw(position, Color.red);
        dragForce.Draw(position, Color.cyan);

        frontalArea = transform.localScale.x;
    }

    private void FixedUpdate()
    {
        aceleracion *= 0;

        weight = mass * gravity;
        weightForce = new CustomVector2(0, weight);

        dragForce = -(0.5f) * (velocity.magnitude * velocity.magnitude) * frontalArea * waterDragCoefficient * velocity.normalized;

        ApplyForce(force);
        ApplyForce(weightForce);
       
        if (position.y < -5)
        {
            ApplyForce(dragForce);
        }

        if (position.x < -5 || position.x > 5)
        {
            position.x = Mathf.Sign(position.x) * 5;
            velocity.x *= -1;
            velocity *= dampingFactor;
        }
        if (position.y < -20 || position.y > 5)
        {
            position.y = Mathf.Sign(position.y) * 20;
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
        aceleracion += force * (1 / mass);
        Move();
    }
}
